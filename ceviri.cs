using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

class Program
{
    static string DbPath = "/Users/bugragunay/Desktop/gezilecek_yerler.db";
    static string TableName = "places";

    
    static int BATCH_SIZE = 25;   // 25 description / batch (100-120 kelime dediğin için iyi)
    static int PAR = 4;           // aynı anda kaç batch işlenecek (OpenAI rate limit'e takılmasın)
    static int MAX_RETRIES = 5;

    static async Task Main()
    {
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Console.WriteLine("❌ OPENAI_API_KEY yok. Terminalde: export OPENAI_API_KEY='sk-...'");
            return;
        }

        Console.WriteLine($"📁 DB: {DbPath}");
        Console.WriteLine($"⚙️ BATCH_SIZE={BATCH_SIZE}, PAR={PAR}");

        using var conn = new SqliteConnection($"Data Source={DbPath}");
        conn.Open();

        using var selectCmd = conn.CreateCommand();
        selectCmd.CommandText = $@"
SELECT id, description
FROM {TableName}
WHERE description IS NOT NULL
  AND description GLOB '*[çğıöşüÇĞİÖŞÜ]*'
";

        using var reader = selectCmd.ExecuteReader();

        var batches = new List<(List<int> ids, List<string> texts)>();
        var ids = new List<int>(BATCH_SIZE);
        var texts = new List<string>(BATCH_SIZE);

        while (reader.Read())
        {
            ids.Add(reader.GetInt32(0));
            texts.Add(reader.GetString(1));

            if (ids.Count >= BATCH_SIZE)
            {
                batches.Add((ids, texts));
                ids = new List<int>(BATCH_SIZE);
                texts = new List<string>(BATCH_SIZE);
            }
        }
        if (ids.Count > 0) batches.Add((ids, texts));

        Console.WriteLine($"📦 Total batches: {batches.Count}");

        using var http = new HttpClient();
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        int totalUpdated = 0;

     
        using var sem = new SemaphoreSlim(PAR);
        var tasks = new List<Task>();

        foreach (var batch in batches)
        {
            await sem.WaitAsync();

            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    int updated = await ProcessBatch(conn, http, batch.ids, batch.texts);
                    Interlocked.Add(ref totalUpdated, updated);
                    Console.WriteLine($"✅ Updated +{updated} | Total={totalUpdated}");
                }
                finally
                {
                    sem.Release();
                }
            }));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine($"\n🏁 DONE. Updated rows: {totalUpdated}");
    }

    static async Task<int> ProcessBatch(SqliteConnection conn, HttpClient http, List<int> ids, List<string> trTexts)
    {
        var translations = await TranslateBatchToEnglish(http, ids, trTexts);

        using var tx = conn.BeginTransaction();

        using var updateCmd = conn.CreateCommand();
        updateCmd.Transaction = tx;
        updateCmd.CommandText = $"UPDATE {TableName} SET description = @desc WHERE id = @id";

        var pDesc = updateCmd.CreateParameter();
        pDesc.ParameterName = "@desc";
        updateCmd.Parameters.Add(pDesc);

        var pId = updateCmd.CreateParameter();
        pId.ParameterName = "@id";
        updateCmd.Parameters.Add(pId);

        int updated = 0;
        foreach (var kv in translations)
        {
            pId.Value = kv.Key;
            pDesc.Value = kv.Value ?? "";
            updated += updateCmd.ExecuteNonQuery();
        }

        tx.Commit();
        return updated;
    }

    static async Task<Dictionary<int, string>> TranslateBatchToEnglish(HttpClient http, List<int> ids, List<string> trTexts)
    {
        var url = "https://api.openai.com/v1/chat/completions";

        string userPayload = BuildUserPayload(ids, trTexts);

        var payload = new
        {
            model = "gpt-4.1-mini",
            temperature = 0.2,
            messages = new object[]
            {
                new {
                    role = "system",
                    content =
@"You are a translation engine.
Translate Turkish to natural, fluent English.
Return ONLY valid JSON in this exact shape:
[
  { ""id"": 123, ""en"": ""..."" },
  { ""id"": 124, ""en"": ""..."" }
]
No extra keys. No commentary. No markdown."
                },
                new { role = "user", content = userPayload }
            }
        };

        var json = JsonSerializer.Serialize(payload);

        for (int attempt = 1; attempt <= MAX_RETRIES; attempt++)
        {
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            using var resp = await http.PostAsync(url, content);
            var respText = await resp.Content.ReadAsStringAsync();

            if (resp.IsSuccessStatusCode)
            {
                using var doc = JsonDocument.Parse(respText);
                var modelText = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                if (string.IsNullOrWhiteSpace(modelText))
                    throw new Exception("Empty model response.");

                var dict = new Dictionary<int, string>();
                using var outDoc = JsonDocument.Parse(modelText);

                foreach (var item in outDoc.RootElement.EnumerateArray())
                {
                    int id = item.GetProperty("id").GetInt32();
                    string en = item.GetProperty("en").GetString() ?? "";
                    dict[id] = en.Trim();
                }

                if (dict.Count != ids.Count)
                    throw new Exception($"Mismatch: expected {ids.Count} items, got {dict.Count}.");

                return dict;
            }

            int code = (int)resp.StatusCode;
            if (code == 429 || code == 500 || code == 502 || code == 503)
            {
                await Task.Delay(700 * attempt);
                continue;
            }

            throw new Exception($"HTTP {code}: {respText}");
        }

        throw new Exception("Too many retries.");
    }

    static string BuildUserPayload(List<int> ids, List<string> trTexts)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Translate these items:");
        sb.AppendLine("[");

        for (int i = 0; i < ids.Count; i++)
        {
            string safe = trTexts[i].Replace("\\", "\\\\").Replace("\"", "\\\"");
            sb.AppendLine($"  {{\"id\": {ids[i]}, \"tr\": \"{safe}\"}}{(i == ids.Count - 1 ? "" : ",")}");
        }

        sb.AppendLine("]");
        return sb.ToString();
    }
}

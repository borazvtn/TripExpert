using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

class Program
{
    
    static string DbPath = "/Users/bugragunay/Desktop/gezilecek_yerler.db";

    static string TableName = "places";

    static async Task Main()
    {
        var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Console.WriteLine("❌ OPENAI_API_KEY yok. Terminalde: export OPENAI_API_KEY='sk-...'");
            return;
        }

        using var conn = new SqliteConnection($"Data Source={DbPath}");
        conn.Open();

        using var selectCmd = conn.CreateCommand();
        selectCmd.CommandText = $"SELECT id, description FROM {TableName}";

        using var reader = selectCmd.ExecuteReader();

        using var http = new HttpClient();
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        int count = 0;

        while (reader.Read())
        {
            var id = reader.GetInt32(0);

            string? tr = reader.IsDBNull(1) ? null : reader.GetString(1);
            if (string.IsNullOrWhiteSpace(tr))
                continue;

            Console.WriteLine($"\n--- ID {id} ---");
            Console.WriteLine("TR: " + tr);

            string en;
            try
            {
                en = await TranslateToEnglish(http, tr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Translate error: " + ex.Message);
                continue;
            }

            Console.WriteLine("EN: " + en);

            using var updateCmd = conn.CreateCommand();
            updateCmd.CommandText = $"UPDATE {TableName} SET description = @desc WHERE id = @id";
            updateCmd.Parameters.AddWithValue("@desc", en);
            updateCmd.Parameters.AddWithValue("@id", id);
            updateCmd.ExecuteNonQuery();

            count++;

            await Task.Delay(150);
        }

        Console.WriteLine($"\n✅ DONE. Updated rows: {count}");
    }

    static async Task<string> TranslateToEnglish(HttpClient http, string turkishText)
    {
        var url = "https://api.openai.com/v1/chat/completions";

        var payload = new
        {
            model = "gpt-4.1-mini",
            temperature = 0.2,
            messages = new object[]
            {
                new { role = "system", content = "Translate the following Turkish text into natural, fluent English. Preserve meaning. Do not add extra commentary." },
                new { role = "user", content = turkishText }
            }
        };

        var json = JsonSerializer.Serialize(payload);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var resp = await http.PostAsync(url, content);
        var respText = await resp.Content.ReadAsStringAsync();

        if (!resp.IsSuccessStatusCode)
            throw new Exception($"HTTP {(int)resp.StatusCode}: {respText}");

        using var doc = JsonDocument.Parse(respText);

        var result = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return (result ?? "").Trim();
    }
}

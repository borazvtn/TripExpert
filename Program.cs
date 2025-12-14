using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace SehirProject
{
    class Program
    {
        
        static readonly List<string> Sehirler = new()
        {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya",
            "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
            "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur",
            "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
            "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum",
            "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
            "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir",
            "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir",
            "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa",
            "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir",
            "Niğde", "Ordu", "Rize", "Sakarya", "Samsun",
            "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat",
            "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van",
            "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman",
            "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan",
            "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye",
            "Düzce"
        };

        const string BaseUrl = "https://www.kulturportali.gov.tr";
        const string DbPath = "gezilecek_yerler.db";

private static readonly string OpenAI_API_KEY = "OPENAI_API_KEY";


        private static readonly HttpClient Http = new HttpClient();

        private static readonly HttpClient HttpImages = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        private static readonly SemaphoreSlim ImageSemaphore = new SemaphoreSlim(5);

        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (!Http.DefaultRequestHeaders.Contains("Authorization"))
            {
                Http.DefaultRequestHeaders.Add("Authorization", $"Bearer {OpenAI_API_KEY}");
            }

            Console.WriteLine("=== Şehir Mekan Scraper (C# + SQLite, URL + BLOB) ===");

            var ilIdMap = await BuildIlIdMapAsync();
            Console.WriteLine($"[INFO] {ilIdMap.Count} il için ilId bulundu.");

            PrepareDatabase();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless=new");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.SuppressInitialDiagnosticInformation = true;

            using var driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromMinutes(5));

            int plate = 1;

            foreach (var city in Sehirler)
            {
                Console.WriteLine($"\n=== {plate:00} - {city} ===");

                List<PlaceInfo> places;
                try
                {
                    places = await FetchPlacesForCityAsync(city, plate, ilIdMap, driver);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] {city} için veri alınamadı: {ex.Message}");
                    plate++;
                    continue;
                }

                Console.WriteLine($"[INFO] {city} -> {places.Count} mekan bulundu.");

                Console.WriteLine($"[INFO] {city} -> {places.Count} mekan için tanıtım ve resim hazırlanıyor (paralel)...");
                var processTasks = new List<Task<(PlaceInfo place, string description, string imgUrl, byte[]? imageBytes)>>();

                foreach (var place in places)
                {
                    processTasks.Add(ProcessPlaceAsync(city, place));
                }

                var processed = await Task.WhenAll(processTasks);
                Console.WriteLine($"[INFO] {city} -> {processed.Length} mekan için tanıtım ve resim hazır.");

                using var conn = new SqliteConnection($"Data Source={DbPath}");
                await conn.OpenAsync();

                foreach (var item in processed)
                {
                    var place = item.place;
                    var description = item.description;
                    var imgUrl = item.imgUrl;
                    var imageBytes = item.imageBytes;

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Places (CityName, PlateNumber, PlaceName, ImageUrl, ImageBlob, Description)
                        VALUES ($city, $plate, $name, $image, $blob, $desc);
                    ";
                    cmd.Parameters.AddWithValue("$city", city);
                    cmd.Parameters.AddWithValue("$plate", plate);
                    cmd.Parameters.AddWithValue("$name", place.PlaceName ?? "");
                    cmd.Parameters.AddWithValue("$image", imgUrl ?? "");
                    cmd.Parameters.AddWithValue("$desc", description);

                    var pBlob = cmd.CreateParameter();
                    pBlob.ParameterName = "$blob";
                    if (imageBytes != null)
                        pBlob.Value = imageBytes;
                    else
                        pBlob.Value = DBNull.Value;
                    cmd.Parameters.Add(pBlob);

                    await cmd.ExecuteNonQueryAsync();
                }

                plate++;
            }

            Console.WriteLine("\n[OK] İşlem tamamlandı. Veriler gezilecek_yerler.db içine yazıldı.");
        }

        static async Task<(PlaceInfo place, string description, string imgUrl, byte[]? imageBytes)> ProcessPlaceAsync(string city, PlaceInfo place)
        {
            string description = await GenerateDescription(city, place.PlaceName);

            var normalizedUrl = NormalizeImageUrl(place.ImageUrl);
            place.ImageUrl = normalizedUrl;

            var imageBytes = await DownloadImageBytesAsync(normalizedUrl);

            return (place, description, normalizedUrl, imageBytes);
        }

        public class PlaceInfo
        {
            public string CityName { get; set; } = "";
            public int PlateNumber { get; set; }
            public string PlaceName { get; set; } = "";
            public string ImageUrl { get; set; } = "";
            public byte[]? ImageBlob { get; set; }
        }

        static string SlugifyCity(string name)
        {
            var map = new Dictionary<char, char>
            {
                ['ç'] = 'c', ['Ç'] = 'c',
                ['ğ'] = 'g', ['Ğ'] = 'g',
                ['ı'] = 'i', ['I'] = 'i',
                ['İ'] = 'i',
                ['ö'] = 'o', ['Ö'] = 'o',
                ['ş'] = 's', ['Ş'] = 's',
                ['ü'] = 'u', ['Ü'] = 'u'
            };

            var sb = new StringBuilder();
            foreach (var ch in name)
            {
                if (ch == ' ')
                {
                    sb.Append('-');
                }
                else if (map.TryGetValue(ch, out var repl))
                {
                    sb.Append(repl);
                }
                else
                {
                    sb.Append(char.ToLowerInvariant(ch));
                }
            }
            return sb.ToString();
        }

        static string NormalizeImageUrl(string? imgSrc)
        {
            if (string.IsNullOrWhiteSpace(imgSrc))
                return "";

            var s = WebUtility.HtmlDecode(imgSrc).Trim();

            if (s.StartsWith("//"))
            {
                return "https:" + s;
            }

            if (s.StartsWith("/"))
            {
                return BaseUrl + s;
            }

            if (!s.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                return BaseUrl.TrimEnd('/') + "/" + s.TrimStart('/');
            }

            return s;
        }

        static async Task<Dictionary<string, string>> BuildIlIdMapAsync()
        {
            var map = new Dictionary<string, string>();

            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(30);
                if (!client.DefaultRequestHeaders.Contains("User-Agent"))
                {
                    client.DefaultRequestHeaders.Add(
                        "User-Agent",
                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0 Safari/537.36");
                }

                var url = $"{BaseUrl}/turkiye/izmir/gezilecekyer";
                var resp = await client.GetAsync(url);
                resp.EnsureSuccessStatusCode();

                var html = await resp.Content.ReadAsStringAsync();
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var targetByNorm = new Dictionary<string, string>();
                foreach (var s in Sehirler)
                {
                    var n = NormalizeCityForIlId(s);
                    if (!targetByNorm.ContainsKey(n))
                        targetByNorm[n] = s;
                }

                var selects = doc.DocumentNode.SelectNodes("//select");
                if (selects != null)
                {
                    foreach (var select in selects)
                    {
                        var options = select.SelectNodes(".//option");
                        if (options == null) continue;

                        foreach (var opt in options)
                        {
                            var rawName = WebUtility.HtmlDecode(opt.InnerText ?? string.Empty).Trim();
                            var value = opt.GetAttributeValue("value", string.Empty).Trim();

                            if (string.IsNullOrWhiteSpace(rawName) || string.IsNullOrWhiteSpace(value))
                                continue;

                            var norm = NormalizeCityForIlId(rawName);

                            if (targetByNorm.TryGetValue(norm, out var canonicalName))
                            {
                                if (!map.ContainsKey(canonicalName))
                                    map[canonicalName] = value;
                            }
                        }
                    }
                }

                var missing = new List<string>();
                foreach (var s in Sehirler)
                {
                    if (!map.ContainsKey(s))
                        missing.Add(s);
                }

                if (missing.Count > 0)
                {
                    Console.WriteLine("[WARN] ilId bulunamayan iller: " + string.Join(", ", missing));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WARN] ilId map'i oluşturulurken hata: {ex.Message}");
            }

            return map;
        }

        static string NormalizeCityForIlId(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            name = WebUtility.HtmlDecode(name);

            // Parantez içlerini (örn. "Merkez" vb.) at
            var idx = name.IndexOf('(');
            if (idx > 0)
                name = name.Substring(0, idx);

            name = name.Trim();

            // Türkçe lower-case
            name = name.ToLower(new CultureInfo("tr-TR"));

            // Birden fazla boşluğu teke indir
            name = Regex.Replace(name, @"\s+", " ");

            return name;
        }

        static async Task<List<PlaceInfo>> FetchPlacesForCityAsync(
            string cityName,
            int plate,
            Dictionary<string, string> ilIdMap,
            IWebDriver driver)
        {
            var slug = SlugifyCity(cityName);
            var baseUrl = $"{BaseUrl}/turkiye/{slug}/gezilecekyer";
            ilIdMap.TryGetValue(cityName, out var ilId);

            string url;
            if (!string.IsNullOrEmpty(ilId))
            {
                url = $"{baseUrl}?ilId={ilId}&keyword=&tur=0&turizmtur=0&gorsel=0&nearest=0&etiket=&sayfa=1&sayi=100&lat=0&lang=0";
            }
            else
            {
                // örn: https://www.kulturportali.gov.tr/turkiye/adana/gezilecekyer
                url = baseUrl;
            }

            var result = new List<PlaceInfo>();

            void ExtractPlaces(HtmlDocument doc)
            {
                var cards = doc.DocumentNode.SelectNodes("//article[contains(@class,'portfolio-item')]");
                if (cards == null)
                    cards = doc.DocumentNode.SelectNodes("//div[contains(@class,'portfolio-item')]");
                if (cards == null)
                    cards = doc.DocumentNode.SelectNodes("//*[contains(@class,'portfolio-item')]");

                if (cards == null)
                    return;

                int countLocal = 0;
                foreach (var art in cards)
                {
                    if (countLocal >= 100) break;

                    var titleNode = art.SelectSingleNode(".//h3//a") ?? art.SelectSingleNode(".//a");
                    var placeName = titleNode?.InnerText.Trim() ?? "";

                    var imgNode = art.SelectSingleNode(".//img");
                    var imgSrc = imgNode?.GetAttributeValue("src", "")?.Trim() ?? "";

                    if (string.IsNullOrWhiteSpace(placeName) && string.IsNullOrWhiteSpace(imgSrc))
                        continue;

                    result.Add(new PlaceInfo
                    {
                        CityName = cityName,
                        PlateNumber = plate,
                        PlaceName = placeName,
                        ImageUrl = imgSrc
                    });

                    countLocal++;
                }
            }

            Console.WriteLine($"[SELENIUM] {cityName} -> {url}");
            try
            {
                driver.Navigate().GoToUrl(url);
            }
            catch (WebDriverException wex)
            {
                Console.WriteLine($"[WARN] {cityName} için URL'e giderken hata: {wex.Message}");
            }

            var doc = new HtmlDocument();
            string html = driver.PageSource;
            doc.LoadHtml(html);

            int maxWaitMs = 15000;  
            int stepMs = 1000;      
            int waited = 0;

            while (waited < maxWaitMs)
            {
                
                var cardsNode = doc.DocumentNode.SelectNodes("//*[contains(@class,'portfolio-item')]");
                if (cardsNode != null && cardsNode.Count > 0)
                    break; // kartlar geldi, daha fazla bekleme

                await Task.Delay(stepMs);
                waited += stepMs;

                html = driver.PageSource;
                doc.LoadHtml(html);
            }

           
            ExtractPlaces(doc);

            if (result.Count == 0)
            {
                Console.WriteLine($"[WARN] {cityName} için hiç *.portfolio-item bulunamadı.");
            }

            Console.WriteLine($"[INFO] {cityName} -> {result.Count} kart bulundu (selenium+htmlagility).");
            return result;
        }

       
        static void PrepareDatabase()
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Places (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    CityName    TEXT    NOT NULL,
                    PlateNumber INTEGER NOT NULL,
                    PlaceName   TEXT    NOT NULL,
                    ImageUrl    TEXT,
                    ImageBlob   BLOB,
                    Description TEXT
                );
            ";
            cmd.ExecuteNonQuery();
        }

        static async Task<string> GenerateDescription(string city, string place)
        {
            if (string.IsNullOrWhiteSpace(place))
            {
                return $"{city} şehrindeki bu mekân için tanıtım metni daha sonra eklenecektir.";
            }

            var payload = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content = "Sen bir turizm rehberisin. Türkiye’deki şehirler ve gezilecek yerler hakkında doğal, bilgilendirici ve akıcı Türkçe tanıtım metinleri yazarsın. Yaklaşık 100-120 kelimelik metinler üret."
                    },
                    new
                    {
                        role = "user",
                        content = $"{city} şehrindeki \"{place}\" adlı mekan için yaklaşık 100-120 kelimelik profesyonel, akıcı ve tamamen Türkçe bir tanıtım metni yaz. Tarihi, konumu, ortamı ve neden görülmeye değer olduğundan bahset."
                    }
                }
            };

            string json = JsonConvert.SerializeObject(payload);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await Http.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var respString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"[WARN] OpenAI API hatası ({response.StatusCode}): {respString}");
                    return $"{city} şehrindeki {place} için tanıtım metni şimdilik eklenemedi.";
                }

                dynamic? result = JsonConvert.DeserializeObject(respString);
                if (result == null)
                {
                    return $"{city} şehrindeki {place} için tanıtım metni daha sonra eklenecektir.";
                }

                string description = result.choices[0]?.message?.content?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(description))
                {
                    return $"{city} şehrindeki {place} için tanıtım metni daha sonra eklenecektir.";
                }

                return description.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WARN] OpenAI çağrısında hata: {ex.Message}");
                return $"{city} şehrindeki {place} için tanıtım metni daha sonra eklenecektir.";
            }
        }

        static async Task<byte[]?> DownloadImageBytesAsync(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            await ImageSemaphore.WaitAsync();
            try
            {
                // Küçük debug log
                Console.WriteLine($"[DEBUG] Resim indiriliyor: {url}");

                var resp = await HttpImages.GetAsync(url);
                resp.EnsureSuccessStatusCode();

                return await resp.Content.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[WARN] Resim indirilemedi: {url} - {ex.Message}");
                // Hata olursa BLOB boş kalsın, URL yine de DB'de olur
                return null;
            }
            finally
            {
                ImageSemaphore.Release();
            }
        }
    }
}

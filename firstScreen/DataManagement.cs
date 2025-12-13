using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace firstScreen
{
    public static class DataManagement
    {
        // -----------------------------------------------------------
        //  MEKAN VERİLERİ (gezilecek_yerler.db)
        // -----------------------------------------------------------
        public static List<Sehir> AllCities { get; set; } = new List<Sehir>();

        private static string placesDbName = "gezilecek_yerler.db";
        private static string placesConnString = $"Data Source={placesDbName};Version=3;";

        public static void LoadPlacesFromDatabase()
        {
            AllCities.Clear();

            if (!File.Exists(placesDbName)) return;

            using (SQLiteConnection conn = new SQLiteConnection(placesConnString))
            {
                conn.Open();
                string sql = "SELECT * FROM Places";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            string dbCityName = reader["CityName"].ToString();
                            int dbPlaka = 0;
                            try { dbPlaka = Convert.ToInt32(reader["PlateNumber"]); } catch { }

                            Sehir mevcutSehir = AllCities.FirstOrDefault(x => x.Name == dbCityName);

                            if (mevcutSehir == null)
                            {
                                mevcutSehir = new Sehir() { Name = dbCityName, Plaka = dbPlaka, Description = dbCityName + " şehri.", ImageFileURL = "" };
                                AllCities.Add(mevcutSehir);
                            }

                            Mekan yeniMekan = new Mekan()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["PlaceName"].ToString(),
                                ImageUrl = reader["ImageUrl"] != DBNull.Value ? reader["ImageUrl"].ToString() : "",
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "",
                                Type = "Genel",
                                TotalScore = 0,
                                VoteCount = 0
                            };
                            mevcutSehir.Mekanlar.Add(yeniMekan);
                        }
                        catch { }
                    }
                }
            }
        }

        // -----------------------------------------------------------
        // KULLANICI VERİLERİ (KullaniciVerileri.db)
        // -----------------------------------------------------------
        private static string userDbName = "KullaniciVerileri.db";
        private static string userConnString = $"Data Source={userDbName};Version=3;";

        public static void InitializeUserDatabase()
        {
            if (!File.Exists(userDbName))
                SQLiteConnection.CreateFile(userDbName);

            using (SQLiteConnection conn = new SQLiteConnection(userConnString))
            {
                conn.Open();

                // 1. Kullanıcılar Tablosu
                string sqlUsers = @"CREATE TABLE IF NOT EXISTS Users (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Nickname TEXT UNIQUE, Password TEXT, UserStatus TEXT);";
                new SQLiteCommand(sqlUsers, conn).ExecuteNonQuery();

                // 2. Puanlama Tablosu
                string sqlRatings = @"CREATE TABLE IF NOT EXISTS UserRatings (ID INTEGER PRIMARY KEY AUTOINCREMENT, UserNickname TEXT NOT NULL, MekanId INTEGER NOT NULL, Score INTEGER NOT NULL, Comment TEXT, UNIQUE(UserNickname, MekanId));";
                new SQLiteCommand(sqlRatings, conn).ExecuteNonQuery();

                // 3. Favoriler Tablosu
                string sqlFavs = @"CREATE TABLE IF NOT EXISTS UserFavorites (UserNickname TEXT NOT NULL, MekanId INTEGER NOT NULL, PRIMARY KEY(UserNickname, MekanId));";
                new SQLiteCommand(sqlFavs, conn).ExecuteNonQuery();
            }
        }

        public static string AddUserToDb(User user)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(userConnString))
                {
                    conn.Open();
                    string checkSql = "SELECT COUNT(*) FROM Users WHERE Nickname = @nick";
                    using (SQLiteCommand cmd = new SQLiteCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nick", user.Nickname);
                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return "Bu kullanıcı adı zaten alınmış.";
                    }

                    string insertSql = "INSERT INTO Users (Name, Nickname, Password, UserStatus) VALUES (@name, @nick, @pass, @status)";
                    using (SQLiteCommand cmd = new SQLiteCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", user.Name);
                        cmd.Parameters.AddWithValue("@nick", user.Nickname);
                        cmd.Parameters.AddWithValue("@pass", user.Password);
                        cmd.Parameters.AddWithValue("@status", user.UserStatus);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Registered succesfully";
            }
            catch (Exception ex) { return "Database error! " + ex.Message; }
        }

        // --- PUANLAMA METOTLARI (Eksik olan buydu) ---
        public static void InsertUserRating(string userNick, int mekanId, int score, string comment)
        {
            using (var conn = new SQLiteConnection(userConnString))
            {
                conn.Open();
                string query = "INSERT OR REPLACE INTO UserRatings (UserNickname, MekanId, Score, Comment) VALUES (@u, @m, @s, @c)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", userNick);
                    cmd.Parameters.AddWithValue("@m", mekanId);
                    cmd.Parameters.AddWithValue("@s", score);
                    cmd.Parameters.AddWithValue("@c", comment);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateMekanRating(Mekan mekan)
        {
            // Veritabanında puan sütunları olmadığı için boş bırakıyoruz, hata vermesin.
        }

        public static void LoadUserRatings(User user)
        {
            user.MyRatings.Clear();
            // Şimdilik boş
        }

        // --- FAVORİ İŞLEMLERİ ---
        public static void FavoriEkle(string nick, int mekanId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(userConnString))
            {
                conn.Open();
                string sql = "INSERT OR IGNORE INTO UserFavorites (UserNickname, MekanId) VALUES (@nick, @id)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nick", nick);
                    cmd.Parameters.AddWithValue("@id", mekanId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void FavoriSil(string nick, int mekanId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(userConnString))
            {
                conn.Open();
                string sql = "DELETE FROM UserFavorites WHERE UserNickname = @nick AND MekanId = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nick", nick);
                    cmd.Parameters.AddWithValue("@id", mekanId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void FavorileriGetir(User user)
        {
            // İŞTE DÜZELTME BURADA: MyFavorites DEĞİL, Favorites OLACAK
            user.Favorites.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(userConnString))
            {
                conn.Open();
                string sql = "SELECT MekanId FROM UserFavorites WHERE UserNickname = @nick";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nick", user.Nickname);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            Mekan m = AllCities.SelectMany(c => c.Mekanlar).FirstOrDefault(x => x.Id == id);
                            if (m != null)
                            {
                                // İŞTE DÜZELTME BURADA DA:
                                user.Favorites.Add(m);
                            }
                        }
                    }
                }
            }
        }

        public static User GetUserFromDb(string nickname, string password)
        {
            using (SQLiteConnection conn = new SQLiteConnection(userConnString))
            {
                conn.Open();
                string sql = "SELECT * FROM Users WHERE Nickname = @nick AND Password = @pass";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nick", nickname);
                    cmd.Parameters.AddWithValue("@pass", password);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User u = new User();
                            u.Name = reader["Name"].ToString();
                            u.Nickname = reader["Nickname"].ToString();
                            u.Password = reader["Password"].ToString();
                            u.UserStatus = reader["UserStatus"].ToString();

                            // Favorileri yükle
                            FavorileriGetir(u);

                            return u;
                        }
                    }
                }
            }
            return null;
        }
    }
}
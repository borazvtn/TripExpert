using System;
using Microsoft.Data.Sqlite;

class UserActionRepository
{
    private const string ConnectionString = "Data Source=/Users/bugragunay/Desktop/gezilecek_yerler.db";


    public static void InsertUserAction(
        string username,
        string password,
        string placeName,
        double rating,
        bool isFavorite)
    {
        using (var conn = new SqliteConnection(ConnectionString))
        {
            conn.Open();

            string sql = @"
                INSERT INTO user_actions (username, password, place_name, rating, is_favorite)
                VALUES (@username, @password, @place_name, @rating, @is_favorite);
            ";

            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@place_name", placeName);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@is_favorite", isFavorite ? 1 : 0);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

class UserDatabaseInitializer
{
    private const string UserDbPath = "/Users/bugragunay/Desktop/KullaniciVerileri.db";

    public static void InitializeUserDatabase()
    {
        using (var conn = new SqliteConnection($"Data Source={UserDbPath}"))
        {
            conn.Open();

            string createUsersTable = @"
                CREATE TABLE IF NOT EXISTS Users (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    Nickname TEXT UNIQUE,
                    Password TEXT,
                    UserStatus TEXT
                );
            ";

            string createUserRatingsTable = @"
                CREATE TABLE IF NOT EXISTS UserRatings (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserNickname TEXT,
                    MekanId INTEGER,
                    Score INTEGER,
                    Comment TEXT,
                    UNIQUE(UserNickname, MekanId)
                );
            ";

            using (var cmd = new SqliteCommand(createUsersTable, conn))
            {
                cmd.ExecuteNonQuery();
            }

            using (var cmd = new SqliteCommand(createUserRatingsTable, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}

class MekanlarDatabaseInitializer
{
    private const string MekanlarDbPath = "/Users/bugragunay/Desktop/gezilecek_yerler.db";

    public static void InitializeMekanlarTables()
    {
        using (var conn = new SqliteConnection($"Data Source={MekanlarDbPath}"))
        {
            conn.Open();

            string createMekanlarTable = @"
                CREATE TABLE IF NOT EXISTS Mekanlar (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    PlaceName TEXT,
                    CityName TEXT,
                    Description TEXT,
                    Type TEXT,
                    ImageUrl TEXT,
                    Rating REAL,
                    TotalScore INTEGER,
                    VoteCount INTEGER
                );
            ";

            using (var cmd = new SqliteCommand(createMekanlarTable, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Kullanıcı Mekan Puanlama Sistemi ===");

        UserDatabaseInitializer.InitializeUserDatabase();
        MekanlarDatabaseInitializer.InitializeMekanlarTables();

        Console.WriteLine("Veritabanları ve tablolar hazır kanka.");
        Console.WriteLine("Bu console app sadece kurulum için; kullanıcı adı / şifre / puan uygulamanın arayüzünden gelecek.");
        Console.WriteLine("Çıkmak için Enter'a bas.");
        Console.ReadLine();
    }
}

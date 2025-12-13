using System.Collections.Generic;

namespace firstScreen
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string UserStatus { get; set; }

        public List<Mekan> Favorites { get; set; } = new List<Mekan>();
        public List<UserRatings> MyRatings { get; set; } = new List<UserRatings>();

        public User() { }

        public User(string name, string password, string nickname, string userStatus)
        {
            Name = name;
            Password = password;
            Nickname = nickname;
            UserStatus = userStatus;
        }

        public void RateMekan(Mekan mekan, int score, string comment)
        {
            if (score < 1) score = 1;
            if (score > 5) score = 5;

            var existingRating = MyRatings.Find(r => r.Mekan.Id == mekan.Id);

            if (existingRating != null)
            {
                mekan.TotalScore -= existingRating.Score;
                mekan.TotalScore += score;
                existingRating.Score = score;
                existingRating.Comment = comment;
            }
            else
            {
                mekan.AddPoint(score);
                var newRating = new UserRatings(mekan, score, comment);
                MyRatings.Add(newRating);
            }

            DataManagement.InsertUserRating(this.Nickname, mekan.Id, score, comment);
            DataManagement.UpdateMekanRating(mekan);
        }

        // --- GÜNCELLENEN METOT BURASI ---
        public bool ToggleFavorite(Mekan mekan)
        {
            Mekan foundMekan = Favorites.Find(m => m.Id == mekan.Id);

            if (foundMekan != null)
            {
                // Listeden çıkar
                Favorites.Remove(foundMekan);
                mekan.ChangeFavorite(false);

                // VERİTABANINDAN SİL [YENİ]
                DataManagement.FavoriSil(this.Nickname, mekan.Id);

                return false;
            }
            else
            {
                // Listeye ekle
                Favorites.Add(mekan);
                mekan.ChangeFavorite(true);

                // VERİTABANINA EKLE [YENİ]
                DataManagement.FavoriEkle(this.Nickname, mekan.Id);

                return true;
            }
        }

        public bool IsFavorite(Mekan mekan)
        {
            return Favorites.Exists(m => m.Id == mekan.Id);
        }
    }
}
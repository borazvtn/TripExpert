namespace firstScreen
{
    public class Mekan
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Type { get; set; }        
        public string ImageUrl { get; set; } 
        
        // Puanlama Sistemi
        public int TotalScore { get; set; } = 0;
        public int VoteCount { get; set; } = 0;
        public int FavoriteCount { get; set; } = 0;

        // Otomatik hesaplanan ortalama
        public double AverageScore
        {
            get
            {
                if (VoteCount == 0) return 0;
                return (double)TotalScore / VoteCount;
            }
        }

        public Mekan() { }

        // Puan Ekleme Metodu
        public void AddPoint(int score)
        {
            TotalScore += score;
            VoteCount++;
        }

        // Favori Güncelleme
        public void ChangeFavorite(bool isAdding)
        {
            if (isAdding) FavoriteCount++;
            else if (FavoriteCount > 0) FavoriteCount--;
        }
    }
}

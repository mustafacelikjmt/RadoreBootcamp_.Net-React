namespace Article.API.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public int WriterId { get; set; }

        public ArticleModel(int ıd, string title, DateTime lastUpdate, int writerId)
        {
            Id = ıd;
            Title = title;
            LastUpdate = lastUpdate;
            WriterId = writerId;
        }

        public ArticleModel()
        {
        }
    }
}
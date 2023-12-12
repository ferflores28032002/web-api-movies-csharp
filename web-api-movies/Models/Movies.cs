namespace web_api_movies.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}

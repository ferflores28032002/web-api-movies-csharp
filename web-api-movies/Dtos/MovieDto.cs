namespace web_api_movies.Dtos
{
    public class MovieDto
    {
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}

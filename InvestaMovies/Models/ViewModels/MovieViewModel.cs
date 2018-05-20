namespace InvestaMovies.Models
{
    /// <summary>
    /// ViewModel/DTO for a movie
    /// </summary>
    public class MovieViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int YearReleased { get; set; }
        public string Rating { get; set; }
    }
}
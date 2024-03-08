namespace TopChart.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Tracks>? Tracks { get; set; }
    }
}

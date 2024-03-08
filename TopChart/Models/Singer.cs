namespace TopChart.Models
{
    public class Singer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Tracks>? Tracks { get; set; }
    }
}

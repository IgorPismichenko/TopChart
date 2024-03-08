namespace TopChart.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Singer? Singer { get; set; }
        public string? Album { get; set; }
        public Genre? Genre { get; set; }
        public Users? User { get; set; }
        public int Like { get; set; }
        public string? Path { get; set; }
    }
}

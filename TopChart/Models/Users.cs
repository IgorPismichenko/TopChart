namespace TopChart.Models
{
    public class Users
    {
        public Users()
        {
            this.Tracks = new HashSet<Tracks>();
        }

        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public int Status { get; set; }
        public ICollection<Tracks>? Tracks { get; set; }
    }
}

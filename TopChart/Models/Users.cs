namespace TopChart.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public int Status { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}

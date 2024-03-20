namespace TopChart.Models
{
    public class CommentVideo
    {
        public int Id { get; set; }
        public string? Message { get; set; }

        public Users? User { get; set; }

        public int UserId { get; set; }
        public Video? Video { get; set; }
        public int VideoId { get; set; }
        public string? Date { get; set; }
    }
}

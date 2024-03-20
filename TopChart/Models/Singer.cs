using System.ComponentModel.DataAnnotations;

namespace TopChart.Models
{
    public class Singer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must be filled")]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        public string? Path { get; set; }
        public ICollection<Tracks>? Tracks { get; set; }
    }
}

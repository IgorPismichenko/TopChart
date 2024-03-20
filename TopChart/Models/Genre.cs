using System.ComponentModel.DataAnnotations;

namespace TopChart.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Genre must be filled")]
        [Display(Name = "Genre")]
        public string? Name { get; set; }
        public ICollection<Tracks>? Tracks { get; set; }
    }
}

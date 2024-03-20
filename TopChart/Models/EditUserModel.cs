using System.ComponentModel.DataAnnotations;

namespace TopChart.Models
{
    public class EditUserModel
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        public int Status { get; set; }
    }
}

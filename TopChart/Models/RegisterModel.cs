using System.ComponentModel.DataAnnotations;

namespace TopChart.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Login must be filled")]
        [Display(Name = "Login")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Password must be filled")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "You must confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string? PasswordConfirm { get; set; }
    }
}

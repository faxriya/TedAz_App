using System.ComponentModel.DataAnnotations;

namespace TedAzApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "TopicId")]
        public int TopicId { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords are different")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}

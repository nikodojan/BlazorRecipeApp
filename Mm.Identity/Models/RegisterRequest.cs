using System.ComponentModel.DataAnnotations;

namespace BlazorRecipeApp.Mm.Identity.Models
{
    public class RegisterRequest
    {
        [MaxLength(50, ErrorMessage = "Names are not allowed to be longer than 50 characters.")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Names are not allowed to be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string PasswordConfirm { get; set; }
    }
}

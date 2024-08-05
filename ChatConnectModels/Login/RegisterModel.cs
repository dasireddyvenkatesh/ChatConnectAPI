using System.ComponentModel.DataAnnotations;

namespace ChatConnectModels.Login
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(12, ErrorMessage = "Password cannot be longer than 12 characters")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?!.* )(?=.*\\d)(?=.*[A-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain at least one digit and one uppercase letter.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        [RegularExpression("^(?!.* )(?=.*\\d)(?=.*[A-Z]).{8,15}$", ErrorMessage = "Confirm Password must be between 8 and 15 characters and contain at least one digit and one uppercase letter.")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}

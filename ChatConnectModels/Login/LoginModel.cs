using System.ComponentModel.DataAnnotations;

namespace ChatConnectModels.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required")]
        [MaxLength(30, ErrorMessage = "UserName cannot be longer than 30 characters")]
        public string UserName {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(12, ErrorMessage = "Password cannot be longer than 12 characters")]
        [DataType(DataType.Password)]
        //[RegularExpression("^(?!.* )(?=.*\\d)(?=.*[A-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain at least one digit and one uppercase letter.")]
        public string Password { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace ChatConnectModels.AccessSentry
{
    public class InsertMethodNameModel
    {

        [Required(ErrorMessage = "MethodName is required.")]
        [RegularExpression(@"^\S+$", ErrorMessage = "MethodName cannot contain spaces.")]
        public string MethodName { get; set; } = string.Empty;

        [Required(ErrorMessage = "ControllerId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ControllerId must be greater than zero.")]
        public int ControllerId { get; set; }

        [Required(ErrorMessage = "At least one role ID is required.")]
        [MinLength(1, ErrorMessage = "At least one role ID is required.")]
        public List<int> Roles { get; set; } = new List<int>();

        [Range(1, 4, ErrorMessage = "HttpTypeId must be greater than zero.")]
        public int HttpTypeId { get; set; }
    }
}

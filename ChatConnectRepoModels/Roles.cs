using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatConnectRepoModels
{
    [Table("Roles", Schema = "ChatConnect")]
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(255)]
        public string RoleName { get; set; } = string.Empty;
    }
}

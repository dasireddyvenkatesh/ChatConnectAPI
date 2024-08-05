using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatConnectRepoModels
{
    [Table("UserRoles", Schema = "ChatConnect")]
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual required Users User { get; set; } 
        public virtual required Roles Role { get; set; } 


    }
}

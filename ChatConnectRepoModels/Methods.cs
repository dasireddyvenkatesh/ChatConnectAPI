using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatConnectRepoModels
{
    [Table("Methods", Schema = "ChatConnect")]
    public class Methods
    {
        [Key]
        public int MethodId { get; set; }

        [Required]
        [MaxLength(255)]
        public required string MethodName { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsAnonymous { get; set; }

        [ForeignKey("Controllers")]
        public int ControllerId { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        [ForeignKey("HttpMethodType")]
        public int HttpTypeId { get; set; }

        public virtual Controllers? Controllers { get; set; }

        public virtual  Roles? Roles { get; set; }

        public virtual HttpMethodType? HttpMethodType { get; set; }
    }
}

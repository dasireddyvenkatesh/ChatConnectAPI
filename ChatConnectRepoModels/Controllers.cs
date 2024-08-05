using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatConnectRepoModels
{
    [Table("Controllers", Schema = "ChatConnect")]
    public class Controllers
    {
        [Key]
        public int ControllerId { get; set; }

        [Required]
        [MaxLength(255)]
        public required string ControllerName { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsAnonymous {  get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatConnectRepoModels
{
    [Table("HttpMethodType", Schema = "ChatConnect")]
    public class HttpMethodType
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Type { get; set; }
    }
}

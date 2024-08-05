using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatConnectRepoModels
{
    [Table("Users", Schema = "ChatConnect")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(1000)]
        public string? Password { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public bool IsEmailVerified { get; set; } = false;

        public DateTime? EmailOtpDate { get; set; }

        public int? EmailOtp { get; set; }

        [Required]
        public int FailedLoginAttempts { get; set; } = 0;

        public DateTime? LockoutEnd { get; set; }

        [MaxLength(1000)]
        public string? SecurityStamp { get; set; }

        [MaxLength(255)]
        public string? DeviceIp { get; set; }

        [Required]
        public bool TwoStepVerfication { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}

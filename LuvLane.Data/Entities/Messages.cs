using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.Identity.Client;

namespace LuvLane.Data.Entities
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }

        [ForeignKey("UserEntity")]
        public string UserSenderId { get; set; } = string.Empty;
        public virtual UserEntity User { get; set; } = null!;

        [ForeignKey("UserEntity")]
        public string UserRecieverId { get; set; } = string.Empty;
        public virtual UserEntity Users { get; set; } = null!;

        [Required, MinLength(1), MaxLength(3000)]
        public string MessageText { get; set; } = string.Empty;

        [Required]
        public DateTime MessageDate { get; set; }
    }
}
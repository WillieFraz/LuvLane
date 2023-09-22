
using System.ComponentModel.DataAnnotations;

namespace LuvLane.Models.Message
{
    public class MessageItem
    {
        public string UserRecieverId { get; set; }

        [MaxLength(3000)]
        public string MessageText { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } 
    }
}
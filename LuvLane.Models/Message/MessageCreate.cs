using System.ComponentModel.DataAnnotations;

namespace LuvLane.Models.Message
{
    public class MessageCreate
    {
        public string UserId { get; set; }

        [MaxLength(3000)]
        public string MessageText { get; set; } = string.Empty;

        [Required]
        public DateTime MessageDate { get; set; }
    }
}
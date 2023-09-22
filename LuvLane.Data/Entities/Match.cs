using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuvLane.Data.Entities
{
    public class Match
    {
        
        public int MatchId { get; set; }

        [Key]
        [ForeignKey("User")]
        public string UserOneId { get; set; } = string.Empty;
        public string UserTwoId { get; set; } = string.Empty;
        public virtual UserEntity User { get; set; } = null!;


        [Required, MinLength(1), MaxLength(100)]
        public string MatchStatus { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<Profile> LoveInterest { get; set; }

    }
}
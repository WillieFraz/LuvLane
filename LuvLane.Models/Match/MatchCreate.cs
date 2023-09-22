using System.ComponentModel.DataAnnotations;

namespace LuvLane.Models.Match;

    public class MatchCreate
    {
        [Required]
        public int MatchId { get; set; }

        [Required]
        public string MatchStatus { get; set; } = string.Empty;

        [Required]
        public string UserOneId { get ; set; }

        [Required]
        public string UserTwoId { get; set; }

   

    }

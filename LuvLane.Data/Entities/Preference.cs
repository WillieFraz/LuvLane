using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuvLane.Data.Entities;

    public class Preferences
    {
               
        [Key]
        public int PreferenceId { get; set; }
        
        [ForeignKey("UserEntity")]
        public string UserPreferenceId { get; set; } 
        public virtual UserEntity User { get; set; } = null!;

        public int LowestAgeRange { get; set; }

        public int HighestAgeRange { get; set; }

        [MinLength(1), MaxLength(100)]
        public string Location { get; set; } = string.Empty;

        public Gender Gender { get; set; }
        
    }

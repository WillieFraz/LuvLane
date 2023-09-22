using System.ComponentModel.DataAnnotations;
using LuvLane.Models.Profile;

namespace LuvLane.Models.Preference;

    public class PreferenceCreate
    {

        [Required]
        [Display(Name = "Above the Age of:")]
        public int LowestAgeRange { get; set; }

        [Required]
        [Display(Name = "Below the age of:")]
        public int HighestAgeRange { get; set; }

        [Required]
        public Gender Gender { get; set; }
}

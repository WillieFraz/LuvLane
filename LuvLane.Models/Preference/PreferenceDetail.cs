using System.ComponentModel.DataAnnotations;
using LuvLane.Models.Profile;

namespace LuvLane.Models.Preference
{
    public class PreferenceDetail
    {
        [Display(Name = "Above the Age of:")]
        public int LowestAgeRange { get; set; }
        
        [Display(Name = "Below the age of:")]
        public int HighestAgeRange { get; set; }

        public Gender Gender { get; set; }
    }
}
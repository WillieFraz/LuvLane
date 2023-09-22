using System.ComponentModel.DataAnnotations;

namespace LuvLane.Models.Profile
{
    public class ProfileEdit
    {
        public string Id { get; set; }

        [Required, MinLength(1), MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MinLength(1), MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required, MinLength(1), MaxLength(8000)]
        public string Bio { get; set; } = string.Empty;
    }
}
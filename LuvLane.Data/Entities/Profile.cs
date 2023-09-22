using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuvLane.Data.Entities;

public class Profile
{ 
    
    [Key]
    public int Profileid { get; set; }

    [ForeignKey("UserEntity")]
    public string UserId { get; set; } = string.Empty;
    public virtual UserEntity User { get; set; } = null!;

    [Required]
    public int Age { get; set; }

    [Required, MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = string.Empty;


    [Required, MinLength(1), MaxLength(8000)]
    public string Bio { get; set; } = string.Empty;

    public Gender Gender { get; set; }

    [Required, MinLength(1), MaxLength(100)]
    public string Location { get; set; } = string.Empty;
}

public enum Gender
{
    Male,
    Female,
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LuvLane.Data.Entities;

public class UserEntity : IdentityUser
{
    [MaxLength(100)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }
}
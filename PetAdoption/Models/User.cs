using System.ComponentModel.DataAnnotations;
using PetAdoption.Models.Enums;

namespace PetAdoption.Models;

public class User : BaseEntity
{
    [Required] [MaxLength(20)] public string UserName { get; set; } = string.Empty;
    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;
    [Required] [MaxLength(256)] [EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] [MaxLength(256)] public string PasswordHash { get; set; } = string.Empty;
    [Phone] public int Phone { get; set; }
    [Required] [MaxLength(85)] public string Address { get; set; } = string.Empty;
    [Required] [MaxLength(168)] public string City { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
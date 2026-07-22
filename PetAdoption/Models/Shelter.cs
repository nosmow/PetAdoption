using System.ComponentModel.DataAnnotations;

namespace PetAdoption.Models;

public class Shelter : BaseEntity
{
    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;
    [Required] [MaxLength(256)] [EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] [Phone] public int Phone { get; set; }
    [Required] [MaxLength(85)] public string Address { get; set; } = string.Empty;
    [Required] [MaxLength(168)] public string City { get; set; } = string.Empty;
}
using System.ComponentModel.DataAnnotations;

namespace PetAdoption.Models;

public class Pet
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;
    [Required] [MaxLength(30)] public string Species { get; set; } = string.Empty;
    [Required] [MaxLength(50)] public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    [MaxLength(10)] public string Gender { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    [MaxLength(30)] public string Color { get; set; } = string.Empty;
    public bool Vaccinated { get; set; }
    public bool Sterilized { get; set; }
    [MaxLength(500)] public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
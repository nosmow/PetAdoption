using PetAdoption.Models.Enums;

namespace PetAdoption.DTOs.Pet;

public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Species Species { get; set; }
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Weight { get; set; }
    public bool Vaccinated { get; set; }
    public bool Sterilized { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
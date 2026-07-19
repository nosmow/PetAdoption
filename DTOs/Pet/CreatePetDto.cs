using System.ComponentModel.DataAnnotations;

namespace PetAdoption.DTOs.Pet;

public class CreatePetDto
{
    [Required] public string Name { get; set; } = string.Empty;

    [Required] public string Species { get; set; } = string.Empty;

    public string Breed { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Gender { get; set; } = string.Empty;

    public decimal Weight { get; set; }

    public string Color { get; set; } = string.Empty;

    public bool Vaccinated { get; set; }

    public bool Sterilized { get; set; }

    public string Description { get; set; } = string.Empty;
}
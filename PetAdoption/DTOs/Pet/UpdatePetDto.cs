using System.ComponentModel.DataAnnotations;
using PetAdoption.Models.Enums;

namespace PetAdoption.DTOs.Pet;

public class UpdatePetDto
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public Species Species { get; set; }
    public string Breed { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal Weight { get; set; }
    public bool Vaccinated { get; set; }
    public bool Sterilized { get; set; }
    public string Description { get; set; } = string.Empty;
}
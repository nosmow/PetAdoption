using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetAdoption.Models.Enums;

namespace PetAdoption.Models;

public class Pet : BaseEntity
{
    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;
    [Required] public Species Species { get; set; }
    [Required] [MaxLength(50)] public string Breed { get; set; } = string.Empty;
    [Required] public Gender Gender { get; set; }
    public int Age { get; set; }
    public decimal Weight { get; set; }
    public bool Vaccinated { get; set; }
    public bool Sterilized { get; set; }
    [MaxLength(500)] public string Description { get; set; } = string.Empty;
    public PetStatus Status { get; set; }
    public int ShelterId { get; set; }
    [ForeignKey(nameof(ShelterId))]
    public Shelter Shelter { get; set; }
}
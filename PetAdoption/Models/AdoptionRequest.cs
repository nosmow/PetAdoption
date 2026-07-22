using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetAdoption.Models.Enums;

namespace PetAdoption.Models;

public class AdoptionRequest : BaseEntity
{
    public int PetId { get; set; }
    [ForeignKey(nameof(PetId))] public Pet Pet { get; set; }
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User User { get; set; }
    [Required] public AdoptionState Status { get; set; }
    [MaxLength(500)] public string Reason { get; set; } = string.Empty;
}
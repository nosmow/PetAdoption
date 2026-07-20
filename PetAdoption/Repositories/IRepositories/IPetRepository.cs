using PetAdoption.Models;

namespace PetAdoption.Repositories.IRepositories;

public interface IPetRepository
{
    Task<ICollection<Pet>> GetPetsAsync();
    Task<Pet?> GetPetByIdAsync(int id);
    Task<ICollection<Pet>> GetPetByNameAsync(string name);
    Task<ICollection<Pet>> GetPetByBreedAsync(string breed);
    Task<bool> ExistingPetAsync(string name, int age, string species, string breed);
    Task<bool> ExistingPetAsync(int id);
    Task<bool> CreatePetAsync(Pet pet);
    Task<bool> UpdatePetAsync(Pet pet);
    Task<bool> DeletePetAsync(Pet pet);
    Task<bool> SaveAsync();
}
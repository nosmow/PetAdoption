using PetAdoption.Models;

namespace PetAdoption.Repositories.IRepositories;

public interface IPetRepository
{
    Task<ICollection<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<bool> ExistingPetAsync(string name, int age, string species, string breed);
    Task<bool> CreateAsync(Pet pet);
    Task<bool> UpdateAsync(Pet pet);
    Task<bool> DeleteAsync(Pet pet);
    Task<bool> SaveAsync();
}
using Microsoft.EntityFrameworkCore;
using PetAdoption.Data;
using PetAdoption.Models;
using PetAdoption.Models.Enums;
using PetAdoption.Repositories.IRepositories;

namespace PetAdoption.Repositories;

public class PetRepository(ApplicationDbContext context) : IPetRepository
{
    public async Task<ICollection<Pet>> GetPetsAsync()
    {
        return await context.Pets
            .Where(p => !p.IsDeleted)
            .OrderBy(p => p.Age)
            .ToListAsync();
    }

    public async Task<Pet> GetPetByIdAsync(int id)
    {
        return await context.Pets
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }

    public async Task<ICollection<Pet>> GetPetByNameAsync(string name)
    {
        string nameTrim = name.ToLower().Trim();
        
        return await context.Pets
            .Where(p => p.Name.ToLower().Contains(nameTrim) && !p.IsDeleted)
            .OrderBy(p => p.Age)
            .ToListAsync();
    }

    public async Task<ICollection<Pet>> GetPetByBreedAsync(string breed)
    {
        string breedTrim = breed.ToLower().Trim();
        
        return await context.Pets
            .Where(p => p.Breed.ToLower().Contains(breedTrim) && !p.IsDeleted)
            .OrderBy(p => p.Age)
            .ToListAsync();
    }

    public async Task<bool> ExistingPetAsync(int id)
    {
        return await context.Pets.AnyAsync(p => p.Id == id);
    }

    public async Task<bool> CreatePetAsync(Pet pet)
    {
        pet.CreatedAt = DateTime.UtcNow;
        pet.UpdatedAt = DateTime.UtcNow;
        
        context.Pets.Add(pet);
        return await SaveAsync();
    }

    public async Task<bool> UpdatePetAsync(Pet pet)
    {
        pet.UpdatedAt = DateTime.UtcNow;
        
        context.Pets.Update(pet);
        return await SaveAsync();
    }

    public async Task<bool> DeletePetAsync(Pet pet)
    {
        pet.UpdatedAt = DateTime.UtcNow;
        pet.IsDeleted = true;
        
        context.Pets.Update(pet);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
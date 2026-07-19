using Microsoft.EntityFrameworkCore;
using PetAdoption.Data;
using PetAdoption.Models;
using PetAdoption.Repositories.IRepositories;

namespace PetAdoption.Repositories;

public class PetRepository(AppDbContext context) : IPetRepository
{
    public async Task<ICollection<Pet>> GetAllAsync()
    {
        return await context.Pets.OrderBy(p => p.Age).ToListAsync();
    }

    public async Task<Pet?> GetByIdAsync(int id)
    {
        return await context.Pets.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> ExistingPetAsync(string name, int age, string species, string breed)
    {
        string nameTrim =  name.ToLower().Trim();
        string speciesTrim = species.ToLower().Trim();
        string breedTrim = breed.ToLower().Trim();
        
        return await context.Pets.AnyAsync(p => 
            p.Name.ToLower().Trim() == nameTrim &&
            p.Age == age &&
            p.Species.ToLower().Trim( )==  speciesTrim &&
            p.Breed.ToLower().Trim() == breedTrim);
    }

    public async Task<bool> CreateAsync(Pet pet)
    {
        pet.CreatedAt = DateTime.UtcNow;
        pet.UpdatedAt = DateTime.UtcNow;
        
        context.Pets.Add(pet);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(Pet pet)
    {
        pet.UpdatedAt = DateTime.UtcNow;
        
        context.Pets.Update(pet);
        return await SaveAsync();
    }

    public async Task<bool> DeleteAsync(Pet pet)
    {
        context.Pets.Remove(pet);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
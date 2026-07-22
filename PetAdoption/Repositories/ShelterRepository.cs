using Microsoft.EntityFrameworkCore;
using PetAdoption.Data;
using PetAdoption.Models;
using PetAdoption.Repositories.IRepositories;

namespace PetAdoption.Repositories;

public class ShelterRepository(ApplicationDbContext context) : IShelterRepository
{
    private readonly ApplicationDbContext context = context;

    public async Task<ICollection<Shelter>> GetSheltersAsync()
    {
        return await context.Shelters
            .Where(s => !s.IsDeleted)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<Shelter> GetShelterByIdAsync(int id)
    {
        return await context.Shelters
            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
    }

    public async Task<ICollection<Shelter>> GetShelterByNameAsync(string name)
    {
        string nameTrim = name.ToLower().Trim();

        return await context.Shelters
            .Where(s => s.Name.ToLower().Contains(nameTrim) && !s.IsDeleted)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<ICollection<Shelter>> GetShelterByCityAsync(string city)
    {
        string cityTrim = city.ToLower().Trim();

        return await context.Shelters
            .Where(s => s.City.ToLower().Contains(cityTrim) && !s.IsDeleted)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task<bool> ExistingShelterAsync(string address, string city)
    {
        string  addressTrim = address.ToLower().Trim();
        string cityTrim = city.ToLower().Trim();
        
        return await context.Shelters.AnyAsync(s => 
            s.Address.ToLower().Trim() == addressTrim && 
            s.City.ToLower().Trim() == cityTrim && 
            !s.IsDeleted);
    }

    public async Task<bool> ExistingShelterAsync(int id)
    {
        return await context.Shelters.AnyAsync(s => s.Id == id);
    }

    public async Task<bool> CreateShelterAsync(Shelter shelter)
    {
        shelter.CreatedAt = DateTime.UtcNow;
        
        context.Shelters.Add(shelter);
        return await SaveAsync();
    }

    public async Task<bool> UpdateShelterAsync(Shelter shelter)
    {
        context.Shelters.Update(shelter);
        return await SaveAsync();
    }

    public async Task<bool> DeleteShelterAsync(Shelter shelter)
    {
        shelter.IsDeleted = true;
        context.Shelters.Update(shelter);
        return await SaveAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
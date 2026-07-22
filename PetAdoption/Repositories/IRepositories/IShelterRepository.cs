using PetAdoption.Models;

namespace PetAdoption.Repositories.IRepositories;

public interface IShelterRepository
{
    Task<ICollection<Shelter>> GetSheltersAsync();
    Task<Shelter> GetShelterByIdAsync(int id);
    Task<ICollection<Shelter>> GetShelterByNameAsync(string name);
    Task<ICollection<Shelter>> GetShelterByCityAsync(string city);
    Task<bool> ExistingShelterAsync(string address, string city);
    Task<bool> ExistingShelterAsync(int id);
    Task<bool> CreateShelterAsync(Shelter shelter);
    Task<bool> UpdateShelterAsync(Shelter shelter);
    Task<bool> DeleteShelterAsync(Shelter shelter);
    Task<bool> SaveAsync();
}
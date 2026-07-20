using Microsoft.EntityFrameworkCore;
using PetAdoption.Models;

namespace PetAdoption.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Pet> Pets => Set<Pet>();
}
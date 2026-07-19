using Microsoft.EntityFrameworkCore;
using PetAdoption.Models;

namespace PetAdoption.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Pet> Pets => Set<Pet>();
}
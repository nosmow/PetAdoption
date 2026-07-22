using Microsoft.EntityFrameworkCore;
using PetAdoption.Models;

namespace PetAdoption.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Shelter> Shelters => Set<Shelter>();
    public DbSet<AdoptionRequest> AdoptionRequests => Set<AdoptionRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>()
            .Property(p => p.Weight)
            .HasColumnType("decimal(18,2)");
    }
}
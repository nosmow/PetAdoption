using Mapster;
using Microsoft.EntityFrameworkCore;
using PetAdoption.Data;
using PetAdoption.Repositories;
using PetAdoption.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

//Connection String
var dbConnectionString = builder.Configuration.GetConnectionString("SqlConnection");

//Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(dbConnectionString));

// Add services to the container.
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IShelterRepository, ShelterRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Mapper
TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Mapster;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.DTOs.Pet;
using PetAdoption.Models;
using PetAdoption.Repositories.IRepositories;

namespace PetAdoption.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController(IPetRepository repository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAll()
    {
        ICollection<Pet> pets = await repository.GetAllAsync();
        List<PetDto> petsDto = pets.Adapt<List<PetDto>>();
        return Ok(petsDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreatePetDto? dto)
    {
        if (!ModelState.IsValid || dto == null)
            return BadRequest(ModelState);
        
        //string name, int age, string species, string breed

        bool existingPet = await repository.ExistingPetAsync(dto.Name, dto.Age, dto.Species, dto.Breed);
        
    }
}
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
    [HttpGet(Name = $"{nameof(GetPets)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetPets()
    {
        ICollection<Pet> pets = await repository.GetPetsAsync();
        List<PetDto> petsDto = pets.Adapt<List<PetDto>>();
        return Ok(petsDto);
    }
    
    [HttpGet("{petId:int}", Name = $"{nameof(GetPet)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPet(int petId)
    {
        Pet pet = await repository.GetPetByIdAsync(petId);
        
        if (pet == null)
            return NotFound();
        
        PetDto petDto = pet.Adapt<PetDto>();
        return Ok(petDto);
    }
    
    [HttpGet("name/{name}", Name = $"{nameof(GetPetByName)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            ModelState.AddModelError("", "Pet name is required.");
            return StatusCode(403, ModelState);
        }
        
        ICollection<Pet> pets = await repository.GetPetByNameAsync(name);
        List<PetDto> petsDto = pets.Adapt<List<PetDto>>();
        return Ok(petsDto);
    }
    
    [HttpGet("breed/{breed}", Name = $"{nameof(GetPetByBreed)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPetByBreed(string breed)
    {
        if (string.IsNullOrEmpty(breed))
        {
            ModelState.AddModelError("", "Breed is required.");
            return StatusCode(403, ModelState);
        }
        
        ICollection<Pet> pets = await repository.GetPetByBreedAsync(breed);
        List<PetDto> petsDto = pets.Adapt<List<PetDto>>();
        return Ok(petsDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePet([FromBody] CreatePetDto dto)
    {
        if (!ModelState.IsValid || dto == null)
            return BadRequest(ModelState);

        Pet pet = dto.Adapt<Pet>();
        
        bool result = await repository.CreatePetAsync(pet);
        
        if (result)
            return CreatedAtRoute($"{nameof(GetPet)}", new { petId = pet.Id }, pet);
        
        ModelState.AddModelError("", $"Error saving {pet.Name}");
        return StatusCode(404, ModelState);
    }
    
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdatePet([FromBody] UpdatePetDto dto)
    {
        if (!ModelState.IsValid || dto == null)
            return BadRequest(ModelState);
        
        bool existingPet = await repository.ExistingPetAsync(dto.Id);

        if (!existingPet)
        {
            ModelState.AddModelError("", "Pet does not exist.");
            return StatusCode(404, ModelState);
        }

        Pet pet = dto.Adapt<Pet>();
        
        bool result = await repository.UpdatePetAsync(pet);

        if (result)
            return NoContent();
        
        ModelState.AddModelError("", $"Error updating {pet.Name}");
        return StatusCode(404, ModelState);
    }
    
    [HttpDelete("{petId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletePet(int petId)
    {
        bool existingPet = await repository.ExistingPetAsync(petId);

        if (!existingPet)
            return NotFound();

        Pet pet = await repository.GetPetByIdAsync(petId);

        if (pet == null)
        {
            ModelState.AddModelError("", $"Pet does not exist by Id {petId}.");
            return StatusCode(404, ModelState);
        }
        
        bool result = await repository.DeletePetAsync(pet);

        if (result)
            return NoContent();
        
        ModelState.AddModelError("", $"Error deleting {petId}");
        return StatusCode(404, ModelState);
    }
}
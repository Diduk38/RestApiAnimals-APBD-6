using Microsoft.AspNetCore.Mvc;
using RestApiAnimals.Models;
using RestApiAnimals.Services;

namespace RestApiAnimals.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class AnimalController:ControllerBase
{
    
    
    private IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
      var animals= _animalService.GetAnimals();
      return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalService.GetAnimal(id);
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var createdAnimal = _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var updatingAnimal = _animalService.UpdateAnimal(id, animal);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteAnimal(int id)
    {
        var deleteAnimal = _animalService.DeleteAnimal(id);
        return NoContent();
    }
}
using WarehouseApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace WarehouseApp.Controllers;

// kontroler animals
[Route("api/animals")]
[ApiController]
public class AnimalsController: ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal {IdAnimal = 1, Name = "Wolf", Description = "Pack - oriented", Category = "Carnivore", Area = "European Forest" },
        new Animal {IdAnimal = 2, Name = "Scorpion", Description = "Snippo", Category = "Carnivore", Area = "Dessert Sands" },
        new Animal {IdAnimal = 3, Name = "Red Panda", Description = "Cute and Fluffy", Category = "Omnivore", Area = "Asian Forest" },
        new Animal {IdAnimal = 4, Name = "Moth", Description = "Lamp Lover", Category = "Herbivore", Area = "Woods" }
    };
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals.OrderBy(animal => ani mal.Name).ToList()); 
    }
    
    [HttpGet("{orderBy}")]
    public IActionResult GetAnimals(string orderBy)
    {
        switch (orderBy)
        {
            case "Name":
                return Ok(_animals.OrderBy(animal => animal.Name).ToList());  
            case "Description":
                return Ok(_animals.OrderBy(animal => animal.Description).ToList());  
            case "Category":
                return Ok(_animals.OrderBy(animal => animal.Category).ToList()); 
            case "Area":
                return Ok(_animals.OrderBy(animal => animal.Area).ToList());   
            default:
                return NotFound($"Cannot resolve {orderBy} as sorting parameter");
        }
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit= _animals.FirstOrDefault(a => a.IdAnimal == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        if (animalToEdit.IdAnimal != animal.IdAnimal)
        {
            return BadRequest("Id cannot be changed");
        };
        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();    
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id, Animal animal)
    {
        var animalToDelete= _animals.FirstOrDefault(a => a.IdAnimal == id);
        if (animalToDelete == null)
        {
            return NoContent();
        }

        _animals.Remove(animalToDelete);
        return NoContent();
    }
}
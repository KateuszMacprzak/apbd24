using AnimalApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace AnimalApp.Controllers;

// kontroler animals
[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal
        {
            IdAnimal = 1, Name = "Lion", Description = "Large carnivorous feline", Category = "Mammals",
            Area = "Savannah"
        },
        new Animal
        {
            IdAnimal = 2, Name = "Tiger", Description = "Big cat with stripes", Category = "Mammals", Area = "Jungle"
        },
        new Animal
        {
            IdAnimal = 3, Name = "Elephant", Description = "Largest land animal", Category = "Mammals",
            Area = "Savannah"
        },
        new Animal
        {
            IdAnimal = 4, Name = "Eagle", Description = "Bird of prey", Category = "Birds", Area = "Mountains"
        },
        new Animal
        {
            IdAnimal = 5, Name = "Shark", Description = "Large predatory fish", Category = "Fish", Area = "Ocean"
        },
        new Animal
        {
            IdAnimal = 6, Name = "Wolf", Description = "Carnivorous mammal", Category = "Mammals", Area = "Forests"
        },
        new Animal
        {
            IdAnimal = 7, Name = "Penguin", Description = "Flightless bird", Category = "Birds", Area = "Antarctica"
        },
        new Animal
        {
            IdAnimal = 8, Name = "Kangaroo", Description = "Marsupial with powerful legs", Category = "Mammals",
            Area = "Australia"
        },
        new Animal
        {
            IdAnimal = 9, Name = "Python", Description = "Large non-venomous snake", Category = "Reptiles",
            Area = "Jungle"
        },
        new Animal
        {
            IdAnimal = 10, Name = "Dolphin", Description = "Intelligent aquatic mammal", Category = "Mammals",
            Area = "Ocean"
        }
    };
    //endpoint pozwalajacy na uzyskanie listy zwierzat
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals.OrderBy(animal => animal.Name).ToList());
    }
    //endpoint pozwalajacy na uzyskanie listy zwierzat z sortowaniem
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
                return Ok(_animals.OrderBy(animal => animal.Description).ToList());
            case "Area":
                return Ok(_animals.OrderBy(animal => animal.Area).ToList());
            // domyslne sortowanie powinno sie odbywac po kolumnie name
            default:
                return Ok(_animals.OrderBy(animal => animal.Name).ToList()); 
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
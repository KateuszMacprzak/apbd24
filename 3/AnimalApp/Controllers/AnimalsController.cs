using Microsoft.AspNetCore.Http.HttpResults;

namespace AnimalApp.Controllers;

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

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals.OrderBy(animal => animal.Name).ToList());
    }

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
}
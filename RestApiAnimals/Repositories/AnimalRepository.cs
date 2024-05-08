using RestApiAnimals.Models;

namespace RestApiAnimals.Repositories;

public class AnimalRepository:IAnimalRepository
{
   
    internal static List<Animal> _animals =
    [
        new Animal
        {
            Id = 1,
            Name = "Nazar",
            Category = "Cat",
            ColorOfFur = "Black",
            Weight = 15.4
        },
        new Animal
        {
            Id = 2,
            Name = "Vova",
            Category = "Vovk",
            ColorOfFur = "Gray",
            Weight = 15.4
        },
        new Animal
        {
            Id = 3,
            Name = "Lisa",
            Category = "Dragon",
            ColorOfFur = "Green",
            Weight = 1542.4
        }
    ];
    
    
    
    public IEnumerable<Animal> GetAnimals()
    {
        return _animals;
    }

    public Animal GetAnimal(int id)
    {
        return _animals.Find(animal => animal.Id == id);
    }

    public int CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return 1;
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        var updatingAnimal = _animals.Find(animal=>animal.Id==id);
        updatingAnimal?.Copy(animal);
        return 1;
    }

    public int DeleteAnimal(int id)
    {
        return _animals.RemoveAll(animal=>animal.Id==id);
    }
    
}
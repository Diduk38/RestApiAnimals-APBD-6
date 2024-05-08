using RestApiAnimals.Models;
using RestApiAnimals.Repositories;

namespace RestApiAnimals.Services;

public class AnimalService:IAnimalService
{

    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }


    public IEnumerable<Animal> GetAnimals()
    {
        return _animalRepository.GetAnimals();
    }

    public Animal GetAnimal(int id)
    {
        return _animalRepository.GetAnimal(id);
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        return _animalRepository.UpdateAnimal(id,animal);
    }

    public int DeleteAnimal(int id)
    {
        return _animalRepository.DeleteAnimal(id);
    }
}
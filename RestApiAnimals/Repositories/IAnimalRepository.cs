using RestApiAnimals.Models;

namespace RestApiAnimals.Repositories;

public interface IAnimalRepository
{
    public IEnumerable<Animal> GetAnimals();

    public Animal GetAnimal(int id);

    public int CreateAnimal(Animal animal);

    public int UpdateAnimal(int id, Animal animal);

    public int DeleteAnimal(int id);

}
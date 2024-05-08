namespace RestApiAnimals.Models;

public class Animal
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Category { get; set; }
    public double Weight { get; set; }
    public string ColorOfFur { get; set; }

    public void Copy(Animal animal)
    {
        Id = animal.Id;
        Name = animal.Name;
        Category = animal.Category;
        Weight = animal.Weight;
        ColorOfFur = animal.ColorOfFur;
    }
    
}
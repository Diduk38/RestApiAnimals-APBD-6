namespace RestApiAnimals.Models;

public class Visit
{
    public DateTime DateTime { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
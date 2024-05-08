using RestApiAnimals.Models;

namespace RestApiAnimals.Repositories;

public class VisitRepository:IVisitRepository
{

    private static List<Visit> _visits = new List<Visit>
    {
       new Visit()
       {
           Animal = AnimalRepository._animals[1],
           Price = 154.3,
           Description = "Good",
           DateTime = new DateTime(2024,03,24)
       }
       ,
       new Visit()
       {
       Animal = AnimalRepository._animals[0],
       Price = 121.3,
       Description = "Normally",
       DateTime = new DateTime(2021,06,21)
    }
       
    };

    
    public IEnumerable<Visit> GetVisits()
    {
        return _visits;
    }

    public int CreateVisit(Visit visit)
    {
        _visits.Add(visit);
        return 1;
    }
    
    
}
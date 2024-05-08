using RestApiAnimals.Models;

namespace RestApiAnimals.Repositories;

public interface IVisitRepository
{
    public IEnumerable<Visit> GetVisits();
    
    public int CreateVisit(Visit visit);
    
}
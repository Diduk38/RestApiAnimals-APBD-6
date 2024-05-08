using RestApiAnimals.Models;

namespace RestApiAnimals.Services;

public interface IVisitService
{
    public IEnumerable<Visit> GetVisits();
    
    public int CreateVisit(Visit visit);
}
using RestApiAnimals.Models;
using RestApiAnimals.Repositories;

namespace RestApiAnimals.Services;

public class VisitService:IVisitService
{

    private IVisitRepository _visitRepository;

    public VisitService(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }


    public IEnumerable<Visit> GetVisits()
    {
        return _visitRepository.GetVisits();
    }

    public int CreateVisit(Visit visit)
    {
        return _visitRepository.CreateVisit(visit);
    }
    
}
using Microsoft.AspNetCore.Mvc;
using RestApiAnimals.Models;
using RestApiAnimals.Services;

namespace RestApiAnimals.Controllers;



[Route("/api/v1/[controller]")]
[ApiController]
public class VisitController:ControllerBase
{

    private readonly IVisitService _visitService;

    public VisitController(IVisitService visitService)
    {
        _visitService = visitService;
    }


    [HttpGet]
    public IActionResult GetVisits()
    {
        var result = _visitService.GetVisits();
        return Ok(result);
    }

    [HttpPost]

    public IActionResult CreateVisit(Visit visit)
    {
        var result = _visitService.CreateVisit(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}
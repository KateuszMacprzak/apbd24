using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Kolos_DB_First.Models.DTO;
using Kolos_DB_First.Repositories;

namespace Kolos_DB_First.Controllers;
[Route("api/trips")]
[ApiController]
public class TripController
{
    private readonly ITripRepository _repository;

    public TripController(ITripRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        throw new NotImplementedException();
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AddTripToClient([FromRoute] int idTrip, [FromBody] AssignClientToTripDTO dto)
    {
        throw new NotImplementedException();
    }
        
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/trips")]
    public class TripsController : ControllerBase
    {
        private readonly S25367Context _context;

        public TripsController(S25367Context context)
        {
            _context = context;
        }
        /*
        1.. Końcówkę odpowiadającą na żądania HTTP GET wysyłane na adres
        /api/trips
        2. Końcówka powinna zwrócić listę podróży w kolejności posortowanej
        malejącą po dacie rozpoczęcia wycieczki.
        */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDTO>>> GetTrips()
        {
            var trips = await _context.Trips
                .OrderByDescending(t => t.DateFrom)
                .Select(t => new TripDTO
                {
                    IdTrip = t.IdTrip,
                    Name = t.Name,
                    Description = t.Description,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    MaxPeople = t.MaxPeople
                })
                .ToListAsync();

            return Ok(trips);
        }
    }

    public class TripDTO
    {
        public int IdTrip { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
    }
}
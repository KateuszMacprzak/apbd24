using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBFirst.Models;
using System.Threading.Tasks;
using System.Linq;


namespace DBFirst.Controllers
{
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {   
        //TODO
        private readonly YourDbContext _context;

        public TripsController(YourDbContext _context)
        {
            _context = _context;
        }
        
        // GET: api/trips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            return await _context.Trips.OrderByDescending(t => t.StartDate).ToListAsync();
        }
        
        // POST : api/trips/{idTrip}/clients
        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AddClientToTrip(int idTrip, [FromBody] ClientDto clientDto)
        {
            var trip = await _context.Trips.FindAsync(idTrip);
            if (trip == null)
            {
                return NotFound("Trip not found");
            }

            var client = await _context.Clients.SingleOrDefaultAsync(c => c.Pesel == clientDto.Pesel);
            if (client == null)
            {
                client = new Client { Pesel = clientDto.Pesel, Name = clientDto.Name };
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
            }

            if (await _context.ClientTrips.AnyAsync(ct => ct.ClientId == client.ClientId && ct.TripId == idTrip))
            {
                return BadRequest("Client is already registered for this trip");
            }

            var clientTrip = new ClientTrip
            {
                ClientId = client.ClientId,
                TripId = idTrip,
                RegisteredAt = DateTime.Now
            };

            _context.ClientTrips.Add(clientTrip);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
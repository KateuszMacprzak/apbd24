using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBFirst.Models;
using System.Threading.Tasks;
using System.Linq;


namespace DBFirst.Controllers;
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly YourDbContext _context;

        public ClientsController(YourDbContext context)
        {
            _context = context;
        }
        
        //DELETE: api/clients/{idClient}
        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var client = await _context.Clients.Include(c => c.clientTrips)
                .FirstOrDefaultAsync(c => c.ClientId == idClient);
            if (client == null)
            {
                return NotFound("Client not found");
            }

            if (client.ClientTrips.Any())
            {
                return BadRequest("Client has assigned trips, cannot delete");
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
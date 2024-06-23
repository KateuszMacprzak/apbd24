using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly S25367Context _context;

        public ClientsController(S25367Context context)
        {
            _context = context;
        }
        /*
        Przygotuj końcówkę pozwalającą na usunięcie danych klienta.
        1. Końcówka przyjmująca dane wysłane na adres HTTP DELETE na
        adres /api/clients/{idClient}
        2. Końcówka powinna najpierw sprawdzić czy klient nie posiada
        żadnych przypisanych wycieczek. Jeśli klient posiada co najmniej
        jedną przypisaną wycieczkę – zwracamy błąd i usunięcie nie
        dochodzi do skutku.
         */
        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var client = await _context.Clients
                .Include(c => c.ClientTrips)
                .FirstOrDefaultAsync(c => c.IdClient == idClient);

            if (client == null)
                return NotFound();

            if (client.ClientTrips.Any())
                return BadRequest("Client has assigned trips and cannot be deleted.");

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        /*
        Przygotuj końcówkę pozwalającą na przypisanie klienta do wycieczki.
        1. Końcówka powinna przyjmować żądania http POST wysłane na adres
        /api/trips/{idTrip}/clients

         */
        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] AssignClientDTO dto)
        {
            var trip = await _context.Trips.FindAsync(idTrip);
            if (trip == null)
                return NotFound("Trip not found.");

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Pesel == dto.Pesel);
            /*
            Czy klient o danym numerze PESEL istnieje. Jeśli nie, dodajemy go do
            bazy danych.
             */
            if (client == null)
            {
                client = new Client
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Telephone = dto.Telephone,
                    Pesel = dto.Pesel
                };
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
            }
            /*
             Czy klient nie jest już zapisaną na wspomnianą wycieczkę – w takim
            wypadku zwracamy błąd.
             */
            var existingClientTrip = await _context.ClientTrips.FindAsync(client.IdClient, idTrip);
            if (existingClientTrip != null)
                return BadRequest("Client is already assigned to this trip.");
            /*
            Czy wycieczka istnieje – jeśli nie – zwracamy błąd.
             */
            var clientTrip = new ClientTrip
            {
                IdClient = client.IdClient,
                IdTrip = idTrip,
                RegisteredAt = DateTime.Now,
                PaymentDate = dto.PaymentDate
            };

            _context.ClientTrips.Add(clientTrip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrips", "Trips", new { id = idTrip }, null);
        }
    }

    public class AssignClientDTO
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Telephone { get; set; } = null!;
        [Required]
        public string Pesel { get; set; } = null!;
        public DateTime? PaymentDate { get; set; }
    }
}


using EFCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly EFCodeFirstDbContext _context;

        public PatientsController(EFCodeFirstDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            var patient = await _context.Patients.Include(p => p.Prescriptions).ThenInclude(pr=> pr.PrescriptionMedicaments).ThenInclude(pm => pm.Medicament).Include(p => p.Prescriptions).ThenInclude(pr => pr.Doctor).FirstOrDefaultAsync(p => p.IdPatient == id);

            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            return Ok(patient);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCodeFirst.Models;


namespace EFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly EFCodeFirstDbContext _context;

        public PrescriptionsController(EFCodeFirstDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionDto prescriptionDto)
        {
            if (prescriptionDto.Medicaments.Count > 10)
            {
                return BadRequest("Prescription cannot have more than 10 medicaments");
            }

            var patient = await _context.Patients.FindAsync(prescriptionDto.PatientId);
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = prescriptionDto.PatientFirstName,
                    LastName = prescriptionDto.PatientLastName,
                    Birthdate = prescriptionDto.PatientBirthdate
                };
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }

            var doctor = await _context.Doctors.FindAsync(prescriptionDto.DoctorId);
            if (doctor == null)
            {
                return BadRequest("Doctor not found");
            }

            var prescription = new Prescription
            {
                Date = prescriptionDto.Date,
                DueDate = prescriptionDto.DueDate,
                Patient = patient,
                Doctor = doctor
            };

            foreach (var med in prescriptionDto.Medicaments)
            {
                var medicament = await _context.Medicaments.FindAsync(med.IdMedicament);
                if (medicament == null)
                {
                    return BadRequest($"Medicament with id {med.IdMedicament} not found");
                }

                prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament
                {
                    Medicament = medicament,
                    Dose = med.Dose,
                    Details = med.Details
                });
            }

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrescriptionById), new { id = prescription.IdPrescription }, prescription);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            var prescription = await _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .Include(p => p.PrescriptionMedicaments)
                    .ThenInclude(pm => pm.Medicament)
                .FirstOrDefaultAsync(p => p.IdPrescription == id);

            if (prescription == null)
            {
                return NotFound("Prescription not found");
            }

            return Ok(prescription);
        }
    }
}

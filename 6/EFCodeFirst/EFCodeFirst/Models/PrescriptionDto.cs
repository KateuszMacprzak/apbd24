namespace EFCodeFirst.Models
{
    public class PrescriptionDto
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientBirthdate { get; set; }
        public int DoctorId { get; set; }
        public List<MedicamentDto> Medicaments { get; set; }
    }
}
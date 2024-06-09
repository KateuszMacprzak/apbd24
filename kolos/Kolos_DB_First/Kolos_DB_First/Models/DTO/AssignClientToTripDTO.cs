namespace Kolos_DB_First.Models.DTO;

public class AssignClientToTripDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string PESEL { get; set; }
    public int TripID { get; set; }
    public string TripName { get; set; }
    public DateTime? PaymentDate { get; set; }
}
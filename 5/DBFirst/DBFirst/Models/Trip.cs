namespace DBFirst.Models;

public class Trip
{
    public int TripId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public ICollection<ClientTrip> ClientTrips { get; set; }
}
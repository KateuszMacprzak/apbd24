namespace DBFirst.Models;

public class Client
{
    public int ClientId { get; set; }
    public string Pesel { get; set; }
    public string Name { get; set; }
    public ICollection<ClientTrip> ClientTrips { get; set; }
}
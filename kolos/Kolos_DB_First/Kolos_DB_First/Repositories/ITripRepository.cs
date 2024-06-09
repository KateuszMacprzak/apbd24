using Kolos_DB_First.Models.DTO;
namespace Kolos_DB_First.Repositories;

public interface ITripRepository
{
    Task<IEnumerable<TripGetDTO>> GetTripsAsync();
    Task AssignTripToClientAsync(int idTrip, AssignClientToTripDTO dto);
}
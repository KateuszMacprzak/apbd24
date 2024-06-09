using Kolos_DB_First.Models.DTO;
namespace Kolos_DB_First.Repositories;

public class TripRepository : ITripRepository
{
    public async Task<IEnumerable<TripGetDTO>> GetTripsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AssignTripToClientAsync(int idTrip, AssignClientToTripDTO dto)
    {
        throw new NotImplementedException();
    }
}
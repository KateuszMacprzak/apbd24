namespace Kolos_DB_First.Models.DTO;

public class TripGetDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public IEnumerable<CountryResponseDTO> Countries { get; set; }
    public IEnumerable<ClientResponseDTO> Clients { get; set; }
}
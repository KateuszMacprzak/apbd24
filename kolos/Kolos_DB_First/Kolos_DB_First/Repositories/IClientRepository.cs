namespace Kolos_DB_First.Repositories;

public interface IClientRepository
{
    public Task DeleteClientAsync(int idClient);

}
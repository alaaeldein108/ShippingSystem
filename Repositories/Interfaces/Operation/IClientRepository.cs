using Data.Entities.Operation;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IClientRepository
    {
        Task AddClientAsync(Client input);
        void UpdateClient(Client input);
        Task<Client> FindClientByIdAsync(string id);
        Task<DataPage<Client>> GetAllClientsAsync(SearchCriteria input);

    }
}

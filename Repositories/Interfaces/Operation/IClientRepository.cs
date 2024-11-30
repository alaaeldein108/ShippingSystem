using Data.Entities.Enums;
using Data.Entities.Finance;
using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IClientRepository
    {
        Task AddClientAsync(Client input);
        void UpdateClient(Client input);
        Task<Client> FindClientByIdAsync(string id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        
    }
}

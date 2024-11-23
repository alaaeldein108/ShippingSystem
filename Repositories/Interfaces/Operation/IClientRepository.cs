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
        Task<Client> FindClientAsync(string input);
        Task<Client> FindClientPhoneAsync(string input);    
        Task<IEnumerable<Client>> GetAllClientsByBranchAsync(string branchName);
        Task<IEnumerable<Client>> GetAllClientsByClientTypeAsync(CustomerTypeEnum customerType);
        Task<IEnumerable<Client>> GetAllClientsByEnablingAsync(StatusEnum isEnable);
        Task<IEnumerable<Client>> GetAllClientsByCreationTimeIntervalAsync(DateTime startTime, DateTime endTime);
        Task<IEnumerable<Client>> GetAllClientsByContractTimeIntervalAsync(DateTime startTime, DateTime endTime);

    }
}

using Data.Context;
using Data.Entities.Enums;
using Data.Entities.Finance;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Operation
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext context;

        public ClientRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddClientAsync(Client input)
        {
            await context.Set<Client>().AddAsync(input);
        }

        public async Task<Client> FindClientAsync(string input)
        {
            return await context.Set<Client>()
                .Where(x=>x.ClientCode==input || x.ClientName==input)
                .FirstOrDefaultAsync();
        }

        public async Task<Client> FindClientPhoneAsync(string input)
        {
            return await context.Set<Client>()
                .Where(x => x.PhoneNumber == input)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClientsByBranchAsync(string branchName)
        {
            return await context.Set<Client>()
                .Include(x => x.CustomerBR)
                .Where(x => x.CustomerBR.Name == branchName).ToListAsync();
                
        }

        public async Task<IEnumerable<Client>> GetAllClientsByClientTypeAsync(CustomerTypeEnum customerType)
        {
            return await context.Set<Client>()
                .Where(x => x.CustomerType == customerType).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClientsByContractTimeIntervalAsync(DateTime startTime, DateTime endTime)
        {
            return await context.Set<Client>()
                        .Where(x => x.ContractStartTime >= startTime && x.ContractEndTime <= endTime)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClientsByCreationTimeIntervalAsync(DateTime startTime, DateTime endTime)
        {
            return await context.Set<Client>()
                       .Where(x => x.CreatedTime >= startTime && x.CreatedTime <= endTime)
                       .ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClientsByEnablingAsync(StatusEnum isEnable)
        {
            return await context.Set<Client>()
                .Where(x=>x.IsEnable == isEnable)
                .ToListAsync();
        }

        public void UpdateClient(Client input)
        {
            context.Set<Client>().AddAsync(input);
        }
    }
}

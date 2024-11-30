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

        public async Task<Client> FindClientByIdAsync(string id)
        {
            return await context.Set<Client>()
                .FirstOrDefaultAsync(x => x.ClientCode == id);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return context.Set<Client>();
        }

        public void UpdateClient(Client input)
        {
            context.Set<Client>().AddAsync(input);
        }
    }
}

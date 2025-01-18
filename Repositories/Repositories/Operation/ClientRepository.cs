using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

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

        public async Task<DataPage<Client>> GetAllClientsAsync(SearchCriteria input)
        {
            Expression<Func<Client, bool>> condition = null;
            condition = a => (a.PhoneNumber.Contains(input.ContactPhone) || string.IsNullOrEmpty(input.ContactPhone)) &&
                            (a.CreatedTime >= input.CreatedTimeFrom && a.CreatedTime <= input.CreatedTimeTo) &&
                             (!input.CustomerType.HasValue || a.CustomerType == input.CustomerType) &&
                            (!input.AffiliatedBranchId.HasValue || a.CustomerBRId == input.AffiliatedBranchId) &&
                            (!input.LevelBranchType.HasValue || a.CustomerBR.LevelType == input.LevelBranchType) &&
                            (!input.Status.HasValue || a.Status == input.Status) &&
                            (a.Creator.Code.Contains(input.UserId) || string.IsNullOrEmpty(input.UserId)) &&
                            (!input.LevelBranchType.HasValue || a.CustomerBR.LevelType == input.LevelBranchType);

            var totalCount = await context.Set<Client>().Where(condition).CountAsync();

            var data = await context.Set<Client>().
                            Include(x => x.CustomerBR)
                            .Include(x => x.Creator)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<Client>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateClient(Client input)
        {
            context.Set<Client>().AddAsync(input);
        }
    }
}

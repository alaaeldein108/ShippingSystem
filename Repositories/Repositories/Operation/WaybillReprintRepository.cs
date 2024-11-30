using Data.Context;
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
    public class WaybillReprintRepository : IWaybillReprintRepository
    {
        private readonly AppDbContext context;

        public WaybillReprintRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddWaybillReprintAsync(WaybillReprint input)
        {
            await context.Set<WaybillReprint>().AddAsync(input);
        }

        public async Task<WaybillReprint> FindWaybillReprintByIdAsync(string id)
        {
            return await context.Set<WaybillReprint>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<WaybillReprint>> GetAllWaybillReprintsAsync()
        {
            return context.Set<WaybillReprint>().Include(x=>x.Order);
        }
    }
}

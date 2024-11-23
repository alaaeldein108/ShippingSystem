using Data.Context;
using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Finance
{
    public class Cash_FODCollectionRepository : ICash_FODCollectionRepository
    {
        private readonly AppDbContext context;

        public Cash_FODCollectionRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddCash_FODCollectionAsync(Cash_FODCollection input)
        {
            await context.Set<Cash_FODCollection>().AddAsync(input);
        }
        public void UpdateCash_FODCollection(Cash_FODCollection input)
        {
            context.Set<Cash_FODCollection>().Update(input);
        }
        public async Task<Cash_FODCollection> FindCash_FODCollectionByWaybillAsync(string waybillNumber)
        {
            return await context.Set<Cash_FODCollection>()
                  .Include(x => x.Order)
                 .Where(x => x.Order.WaybillNumber == waybillNumber)
                 .FirstOrDefaultAsync();
        }
     
    }
}

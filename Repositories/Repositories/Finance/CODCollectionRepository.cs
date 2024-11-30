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
    public class CODCollectionRepository : ICODCollectionRepository
    {
        private readonly AppDbContext context;

        public CODCollectionRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddCODCollectionAsync(COD_Collection input)
        {
            await context.Set<COD_Collection>().AddAsync(input);    
        }

        public async Task<COD_Collection> FindCODCollectionByIdAsync(string billNumber)
        {
            return await context.Set<COD_Collection>()
                 .Include(x => x.Order)
                 .FirstOrDefaultAsync(x => x.BillNumber==billNumber);
        }

        public async Task<IQueryable<COD_Collection>> GetAllCODCollectionsAsync()
        {
            return context.Set<COD_Collection>().Include(x => x.Order);
        }

        public void UpdateCODCollection(COD_Collection input)
        {
            context.Set<COD_Collection>().Update(input);
        }
    }
}

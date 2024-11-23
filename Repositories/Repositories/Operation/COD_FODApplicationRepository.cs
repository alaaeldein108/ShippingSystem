using Data.Context;
using Data.Entities.Operation.COD_FOD_Adjustment;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Operation
{
    public class COD_FODApplicationRepository : ICOD_FODApplicationRepository
    {
        private readonly AppDbContext context;

        public COD_FODApplicationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddCOD_FODApplicationAsync(COD_FOD_Application input)
        {
            await context.Set<COD_FOD_Application>().AddAsync(input);
        }
        public void UpdateCOD_FODApplication(COD_FOD_Application input)
        {
            context.Set<COD_FOD_Application>().AddAsync(input);
        }
        public async Task<IEnumerable<COD_FOD_Application>> GetAllCOD_FODApplicationsByWaybillAsync(string waybillNumber)
        {
            return await context.Set<COD_FOD_Application>()
                .Include(x=>x.Order)
                .Where(x=>x.Order.WaybillNumber== waybillNumber)
                .ToListAsync();
        }

        
    }
}

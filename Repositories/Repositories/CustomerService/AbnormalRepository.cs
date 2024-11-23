using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.CustomerService
{
    public class AbnormalRepository : IAbnormalRepository
    {
        private readonly AppDbContext context;

        public AbnormalRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAbnormalAsync(Abnormal input)
        {
            await context.Set<Abnormal>().AddAsync(input);
        }
        public void UpdateAbnormalAsync(Abnormal input)
        {
            context.Set<Abnormal>().Update(input);
        }
        public async Task<IEnumerable<Abnormal>> GetAllAbnormalsByWaybillAsync(string waybillNumber)
        {
            return await context.Set<Abnormal>()
                .Include(x => x.Order)
                .Include(x => x.Order.PickupBR)
                .Include(x => x.AbnormalSubReason)
                .Include(x => x.AbnormalSubReason.MainReason)
                .Include(x => x.RegisterBr)
                .Where(x => x.Order.WaybillNumber == waybillNumber)
                .ToListAsync();

        }

        
    }
}

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
    public class AbnormalMainReasonRepository : IAbnormalMainReasonRepository
    {
        private readonly AppDbContext context;

        public AbnormalMainReasonRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAbnormalMainReasonAsync(AbnormalMainReason input)
        {
            await context.Set<AbnormalMainReason>().AddAsync(input);
        }

        public void DeleteAbnormalMainReason(AbnormalMainReason input)
        {
            context.Set<AbnormalMainReason>().Remove(input);
        }

        public async Task<AbnormalMainReason> FindAbnormalMainReasonAsync(int id)
        {
            return await context.Set<AbnormalMainReason>()
                .FindAsync(id);

        }

        public async Task<IEnumerable<AbnormalMainReason>> GetAllAbnormalMainReasonsAsync()
        {
            return await context.Set<AbnormalMainReason>().ToListAsync();

        }

        public void UpdateAbnormalMainReason(AbnormalMainReason input)
        {
            context.Set<AbnormalMainReason>().Update(input);
        }
    }
}

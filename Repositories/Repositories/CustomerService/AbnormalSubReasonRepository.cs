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
    public class AbnormalSubReasonRepository : IAbnormalSubReasonRepository
    {
        private readonly AppDbContext context;

        public AbnormalSubReasonRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAbnormalSubReasonAsync(AbnormalSubReason input)
        {
            await context.Set<AbnormalSubReason>().AddAsync(input);
        }

        public void DeleteAbnormalSubReason(AbnormalSubReason input)
        {
            context.Set<AbnormalSubReason>().Remove(input);
        }

        public async Task<AbnormalSubReason> FindAbnormalSubReasonAsync(int id)
        {
            return await context.Set<AbnormalSubReason>()
                           .FindAsync(id);
        }

        public async Task<IEnumerable<AbnormalSubReason>> GetAllAbnormalSubReasonsAsync()
        {
            return await context.Set<AbnormalSubReason>().ToListAsync();
        }

        public void UpdateAbnormalSubReason(AbnormalSubReason input)
        {
            context.Set<AbnormalSubReason>().Update(input);
        }
    }
}

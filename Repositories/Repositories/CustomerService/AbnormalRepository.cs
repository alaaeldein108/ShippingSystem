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
        public void UpdateAbnormal(Abnormal input)
        {
            context.Set<Abnormal>().Update(input);
        }

        public async Task<IQueryable<Abnormal>> GetAllAbnormalsAsync()
        {
            return context.Set<Abnormal>()
               .Include(x => x.Order)
               .Include(x => x.AbnormalSubReason)
               .ThenInclude(x => x.MainReason);
        }

        public async Task<Abnormal> FindAbnormalById(string Number)
        {
            return await context.Set<Abnormal>().FirstOrDefaultAsync(x => x.Number == Number);
        }
    }
}

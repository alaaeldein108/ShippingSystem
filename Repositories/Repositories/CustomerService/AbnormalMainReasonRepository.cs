using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.CustomerService;
using Repositories.Models;
using System.Linq.Expressions;

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

        public async Task<DataPage<AbnormalMainReason>> GetAllAbnormalMainReasonsAsync(SearchCriteria input)
        {
            Expression<Func<AbnormalMainReason, bool>> condition = null;
            condition = a => (a.Code.Contains(input.AbnormalMainReasonCode) || string.IsNullOrEmpty(input.AbnormalMainReasonCode)) &&
                            (a.Code.Contains(input.AbnormalMainReasonType) || string.IsNullOrEmpty(input.AbnormalMainReasonType));

            var totalCount = await context.Set<AbnormalMainReason>().Where(condition).CountAsync();

            var data = await context.Set<AbnormalMainReason>()
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<AbnormalMainReason>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateAbnormalMainReason(AbnormalMainReason input)
        {
            context.Set<AbnormalMainReason>().Update(input);
        }
    }
}

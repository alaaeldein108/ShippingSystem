using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.CustomerService;
using Repositories.Models;
using System.Linq.Expressions;

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
            return await context.Set<AbnormalSubReason>().FindAsync(id);
        }

        public async Task<DataPage<AbnormalSubReason>> GetAllAbnormalSubReasonsAsync(SearchCriteria input)
        {
            Expression<Func<AbnormalSubReason, bool>> condition = null;
            condition = a => (a.Code.Contains(input.AbnormalSubReasonCode) || string.IsNullOrEmpty(input.AbnormalSubReasonCode)) &&
                            (a.Code.Contains(input.AbnormalSubReasonType) || string.IsNullOrEmpty(input.AbnormalSubReasonType)) &&
                            (a.MainReason.Code.Contains(input.AbnormalMainReasonCode) || string.IsNullOrEmpty(input.AbnormalMainReasonCode)) &&
                            (a.MainReason.Code.Contains(input.AbnormalMainReasonType) || string.IsNullOrEmpty(input.AbnormalMainReasonType));

            var totalCount = await context.Set<AbnormalSubReason>().Where(condition).CountAsync();

            var data = await context.Set<AbnormalSubReason>()
                            .Include(x => x.MainReason)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<AbnormalSubReason>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateAbnormalSubReason(AbnormalSubReason input)
        {
            context.Set<AbnormalSubReason>().Update(input);
        }
    }
}

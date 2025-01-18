using Data.Context;
using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Finance;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Finance
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly AppDbContext context;

        public QuotationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddQuotationAsync(Quotation input)
        {
            await context.Set<Quotation>().AddAsync(input);
        }

        public async Task<Quotation> FindQuotationByIdAsync(int id)
        {
            return await context.Set<Quotation>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DataPage<Quotation>> GetAllQuotationsAsync(SearchCriteria input)
        {
            Expression<Func<Quotation, bool>> condition = null;
            condition = a => (a.ClientCode.Contains(input.ClientId) || string.IsNullOrEmpty(input.ClientId)) &&
                             (!input.AffiliatedBranchId.HasValue || a.Client.CustomerBRId == input.AffiliatedBranchId) &&
                             (a.ActivationEndTime <= input.ValidityTime) &&
                            (!input.QuotationAudit.HasValue || a.Auditing == input.QuotationAudit) &&
                            (!input.ProductTypeId.HasValue || a.ProductTypeId == input.ProductTypeId);

            var totalCount = await context.Set<Quotation>().Where(condition).CountAsync();

            var data = await context.Set<Quotation>()
                            .Include(x => x.Client)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<Quotation>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateQuotation(Quotation input)
        {
            context.Set<Quotation>().Update(input);
        }
    }
}

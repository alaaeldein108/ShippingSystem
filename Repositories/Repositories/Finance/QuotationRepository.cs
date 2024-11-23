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

        public async Task<IEnumerable<Quotation>> GetAllQuotationsByAuditingAsync(AuditingEnum auditing)
        {
            return await context.Set<Quotation>()
                .Where(x => x.Auditing == auditing).ToListAsync();
        }

        public async Task<IEnumerable<Quotation>> GetAllQuotationsByBranchAsync(string branchCode)
        {
            return await context.Set<Quotation>()
                           .Where(x => x.AffailiatedBranchCode == branchCode)
                           .ToListAsync();
        }

        public async Task<IEnumerable<Quotation>> GetAllQuotationsByProductTypeAsync(string productTypeCode)
        {
            return await context.Set<Quotation>()
                                .Where(x => x.ProductTypeCode == productTypeCode)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Quotation>> GetAllQuotationsByValidationTimeAsync(DateTime startTime, DateTime endTime)
        {
            return await context.Set<Quotation>()
                         .Where(x => x.ActivationStartTime >= startTime && x.ActivationEndTime <= endTime)
                         .ToListAsync();
        }

        public void UpdateQuotation(Quotation input)
        {
            context.Set<Quotation>().Update(input);
        }
    }
}

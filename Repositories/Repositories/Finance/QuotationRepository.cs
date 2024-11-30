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

        public async Task<Quotation> FindQuotationByIdAsync(int id)
        {
            return await context.Set<Quotation>().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<IQueryable<Quotation>> GetAllQuotationsAsync()
        {
            return context.Set<Quotation>();
        }

        public void UpdateQuotation(Quotation input)
        {
            context.Set<Quotation>().Update(input);
        }
    }
}

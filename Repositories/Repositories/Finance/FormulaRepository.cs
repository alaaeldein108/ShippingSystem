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
    public class FormulaRepository : IFormulaRepository
    {
        private readonly AppDbContext context;

        public FormulaRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddFormulaAsync(Formula input)
        {
            await context.Set<Formula>().AddAsync(input);
        }

        public void DeleteFormula(Formula input)
        {
            context.Set<Formula>().Remove(input);
        }

        public async Task<Formula> FindFormulaByIdAsync(int id)
        {
            return await context.Set<Formula>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Formula>> GetAllFormulasAsync(int quotationId)
        {
            return await context.Set<Formula>()
                .Where(x=>x.QuotationId== quotationId).ToListAsync();

        }
        public void UpdateFormula(Formula input)
        {
            context.Set<Formula>().Update(input);
        }
    }
}

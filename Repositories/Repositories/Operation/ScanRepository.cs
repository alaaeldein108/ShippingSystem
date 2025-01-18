using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class ScanRepository : IScanRepository
    {
        private readonly AppDbContext context;

        public ScanRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddScanAsync(Scan input)
        {
            await context.Set<Scan>().AddAsync(input);
        }

        public async Task<Scan> FindScanByIdAsync(int code)
        {
            return await context.Set<Scan>().FindAsync(code);
        }

        public async Task<DataPage<Scan>> GetAllScansAsync(SearchCriteria input)
        {
            Expression<Func<Scan, bool>> condition = null;
            condition = a => (input.ScanTypeName.HasValue || a.ScanTypeName == input.ScanTypeName) &&
                            (!input.Status.HasValue || a.Status == input.Status);

            var totalCount = await context.Set<Scan>().Where(condition).CountAsync();

            var data = await context.Set<Scan>()
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<Scan>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateScan(Scan input)
        {
            context.Set<Scan>().Update(input);
        }
    }
}

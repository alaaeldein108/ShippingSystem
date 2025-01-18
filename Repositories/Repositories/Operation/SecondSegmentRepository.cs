using Data.Context;
using Data.Entities.Operation.Sorting;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class SecondSegmentRepository : ISecondSegmentRepository
    {
        private readonly AppDbContext context;

        public SecondSegmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddSecondSegmentAsync(SecondSegment input)
        {
            await context.Set<SecondSegment>().AddAsync(input);
        }

        public void DeleteSecondSegment(SecondSegment input)
        {
            context.Set<SecondSegment>().Remove(input);
        }

        public async Task<SecondSegment> FindSecondSegmentByIdAsync(int id)
        {
            return await context.Set<SecondSegment>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<DataPage<SecondSegment>> GetAllSecondSegmentsAsync(SearchCriteria input)
        {
            Expression<Func<SecondSegment, bool>> condition = null;
            condition = a => (!input.AffiliatedBranchId.HasValue || a.BranchId == input.AffiliatedBranchId) &&
                             (!input.Code.HasValue || a.Id == input.Code) &&
                             (!input.Status.HasValue || a.Status == input.Status) &&
                             (a.AreaId.Contains(input.AreaId) || string.IsNullOrEmpty(input.AreaId));

            var totalCount = await context.Set<SecondSegment>().Where(condition).CountAsync();

            var data = await context.Set<SecondSegment>()
                             .Include(x => x.Area)
                             .ThenInclude(x => x.City)
                             .ThenInclude(x => x.Province)
                             .Include(x => x.Branch)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<SecondSegment>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateSecondSegment(SecondSegment input)
        {
            context.Set<SecondSegment>().Update(input);
        }
    }
}

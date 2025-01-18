using Data.Context;
using Data.Entities.Operation.Sorting;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class FirstSegmentRepository : IFirstSegmentRepository
    {
        private readonly AppDbContext context;

        public FirstSegmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddFirstSegmentAsync(FirstSegment input)
        {
            await context.Set<FirstSegment>().AddAsync(input);
        }

        public void DeleteFirstSegment(FirstSegment input)
        {
            context.Set<FirstSegment>().Remove(input);
        }

        public async Task<FirstSegment> FindFirstSegmentByIdAsync(int id)
        {
            return await context.Set<FirstSegment>()
                            .Include(x => x.Area).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DataPage<FirstSegment>> GetAllFirstSegmentsAsync(SearchCriteria input)
        {
            Expression<Func<FirstSegment, bool>> condition = null;
            condition = a => (a.FirstSegmentName.Contains(input.Name) || string.IsNullOrEmpty(input.Name)) &&
                             (!input.Code.HasValue || a.FirstSegmentCode == input.Code) &&
                             (!input.Status.HasValue || a.Status == input.Status);

            var totalCount = await context.Set<FirstSegment>().Where(condition).CountAsync();

            var data = await context.Set<FirstSegment>()
                             .Include(x => x.Area)
                             .ThenInclude(x => x.City)
                             .ThenInclude(x => x.Province)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<FirstSegment>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateFirstSegment(FirstSegment input)
        {
            context.Set<FirstSegment>().Update(input);
        }

    }
}

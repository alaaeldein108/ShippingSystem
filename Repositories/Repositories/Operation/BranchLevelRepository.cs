using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class BranchLevelRepository : IBranchLevelRepository
    {
        private readonly AppDbContext context;

        public BranchLevelRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddBranchLevelAsync(BranchLevel input)
        {
            await context.Set<BranchLevel>().AddAsync(input);
        }

        public void DeleteBranchLevel(BranchLevel input)
        {
            context.Set<BranchLevel>().Remove(input);
        }

        public async Task<BranchLevel> FindBranchLevelByIdAsync(int id)
        {
            return await context.Set<BranchLevel>()
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<DataPage<BranchLevel>> GetAllBranchLevelsAsync(SearchCriteria input)
        {
            Expression<Func<BranchLevel, bool>> condition = null;
            condition = a => (!input.AffiliatedBranchId.HasValue || a.Id == input.AffiliatedBranchId) &&
                            (!input.AffiliatedAgencyId.HasValue || a.AffiliatedAgencyId == input.AffiliatedAgencyId) &&
                            (!input.LevelBranchType.HasValue || a.LevelType == input.LevelBranchType) &&
                            (!input.Status.HasValue || a.Status == input.Status);

            var totalCount = await context.Set<BranchLevel>().Where(condition).CountAsync();

            var data = await context.Set<BranchLevel>()
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<BranchLevel>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateBranchLevel(BranchLevel input)
        {
            context.Set<BranchLevel>().Update(input);
        }

    }
}

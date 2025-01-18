using Data.Context;
using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Finance;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Finance
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly AppDbContext context;

        public ZoneRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddZoneAsync(Zone input)
        {
            await context.Set<Zone>().AddAsync(input);
        }

        public void DeleteZone(Zone input)
        {
            context.Set<Zone>().Remove(input);
        }

        public async Task<Zone> FindZoneByIdAsync(int id)
        {
            return await context.Set<Zone>().FindAsync(id);
        }

        public async Task<DataPage<Zone>> GetAllZonesAsync(SearchCriteria input)
        {
            Expression<Func<Zone, bool>> condition = null;
            condition = a => (a.Name.Contains(input.ZoneName) || string.IsNullOrEmpty(input.ZoneName)) &&
                             (!input.AffiliatedBranchId.HasValue || a.AffailiatedBranchId == input.AffiliatedBranchId) &&
                            (!input.ZoneType.HasValue || a.ZoneType == input.ZoneType);

            var totalCount = await context.Set<Zone>().Where(condition).CountAsync();

            var data = await context.Set<Zone>()
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<Zone>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateZone(Zone input)
        {
            context.Set<Zone>().Update(input);
        }
    }
}

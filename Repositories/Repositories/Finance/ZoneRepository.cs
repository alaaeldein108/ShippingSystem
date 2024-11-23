using Data.Context;
using Data.Entities.Enums;
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

        public async Task<IEnumerable<Zone>> GetAllZonesByBranchAsync(string input)
        {
            return await context.Set<Zone>()
                .Include(x=>x.AffailiatedBranch)
               .Where(x => x.AffailiatedBranch != null && x.AffailiatedBranch.Name == input)
               .ToListAsync();
        }

        public async Task<IEnumerable<Zone>> GetAllZonesByDestinationAsync(string input)
        {
            return await context.Set<Zone>()
                .Where(x=> x.OriginsOrDestinations != null && x.OriginsOrDestinations == input)
                .ToListAsync();
        }

        public async Task<IEnumerable<Zone>> GetAllZonesByNameAsync(string input)
        {
            return await context.Set<Zone>()
               .Where(x => x.Name == input)
               .ToListAsync();
        }

        public async Task<IEnumerable<Zone>> GetAllZonesByQuotationTypeAsync(QuotationTypeEnum quotationType)
        {
            return await context.Set<Zone>().Where(x => x.QuotationType == quotationType).ToListAsync();
        }

        public async Task<IEnumerable<Zone>> GetAllZonesByTypeAsync(ZoneTypeEnum zoneType)
        {
            return await context.Set<Zone>().Where(x => x.ZoneType == zoneType).ToListAsync();
        }

        public void UpdateZone(Zone input)
        {
            context.Set<Zone>().Update(input);
        }
    }
}

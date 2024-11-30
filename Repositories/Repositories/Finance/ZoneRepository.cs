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

        public async Task<Zone> FindZoneByIdAsync(int id)
        {
            return await context.Set<Zone>().FindAsync(id);
        }

        public async Task<IQueryable<Zone>> GetAllZonesAsync()
        {
            return context.Set<Zone>();
        }

        public void UpdateZone(Zone input)
        {
            context.Set<Zone>().Update(input);
        }
    }
}

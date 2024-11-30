using Data.Context;
using Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Addresses
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext context;

        public AreaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IQueryable<Area>> GetAllAreaAsync()
        {
            return context.Set<Area>();
        }

        public async Task<Area> GetAreaById(string code)
        {
            return await context.Set<Area>().Include(x => x.City).ThenInclude(x=>x.Province)
                .FirstOrDefaultAsync(x => x.Id == code);
        }
    }
}

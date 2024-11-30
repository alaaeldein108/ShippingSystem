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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly AppDbContext context;

        public ProvinceRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Province>> GetAllProvincesAsync()
        {
            return await context.Set<Province>().ToListAsync();
        }

        public async Task<Province> GetProvinceById(string code)
        {
            return await context.Set<Province>()
                .FirstOrDefaultAsync(x => x.Id == code);
        }
    }
}

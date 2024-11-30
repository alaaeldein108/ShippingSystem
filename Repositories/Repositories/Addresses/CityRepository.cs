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
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext context;

        public CityRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IQueryable<City>> GetAllCitiesAsync()
        {
            return context.Set<City>().Include(x => x.Province);
        }

        public async Task<City> GetCityById(string code)
        {
            return await context.Set<City>().Include(x => x.Province)
                .FirstOrDefaultAsync(x => x.Id == code);
        }
    }
}

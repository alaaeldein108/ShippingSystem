using Data.Context;
using Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Addresses;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Addresses
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext context;

        public AreaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<DataPage<Area>> GetAllAreaAsync(SearchCriteria input)
        {
            Expression<Func<Area, bool>> condition = null;
            condition = a => (a.Id.Contains(input.AreaId) || string.IsNullOrEmpty(input.AreaId)) &&
                            (a.CityId.Contains(input.CityId) || string.IsNullOrEmpty(input.CityId)) &&
                            (a.City.ProvinceId.Contains(input.ProvinceId) || string.IsNullOrEmpty(input.ProvinceId));

            var totalCount = await context.Set<Area>().Where(condition).CountAsync();

            var data = await context.Set<Area>().Include(x => x.City)
                       .ThenInclude(x => x.Province).Where(condition)
                       .Skip((input.PageIndex - 1) * input.PageSize)
                       .Take(input.PageSize)
                       .ToListAsync();

            return new DataPage<Area>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());

        }

        public async Task<Area> GetAreaById(string code)
        {
            return await context.Set<Area>().Include(x => x.City).ThenInclude(x => x.Province)
                .FirstOrDefaultAsync(x => x.Id == code);
        }
    }
}

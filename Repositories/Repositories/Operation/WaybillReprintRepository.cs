using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class WaybillReprintRepository : IWaybillReprintRepository
    {
        private readonly AppDbContext context;

        public WaybillReprintRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddWaybillReprintAsync(WaybillReprint input)
        {
            await context.Set<WaybillReprint>().AddAsync(input);
        }

        public async Task<WaybillReprint> FindWaybillReprintByIdAsync(Guid id)
        {
            return await context.Set<WaybillReprint>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DataPage<WaybillReprint>> GetAllWaybillReprintsAsync(SearchCriteria input)
        {
            Expression<Func<WaybillReprint, bool>> condition = null;
            condition = a => (input.WaybillNumber == null || !input.WaybillNumber.Any() ||
                            input.WaybillNumber.Contains(a.Order.WaybillNumber)) &&
                            (a.PrintingTime >= input.PrintingScanTimeFrom && a.PrintingTime <= input.PrintingScanTimeTo) &&
                            (a.Printer.Code.Contains(input.UserId) || string.IsNullOrEmpty(input.UserId)) &&
                            (!input.PrintStatus.HasValue || a.PrintStatus == input.PrintStatus);

            var totalCount = await context.Set<WaybillReprint>().Where(condition).CountAsync();

            var data = await context.Set<WaybillReprint>()
                            .Include(x => x.Printer)
                            .Include(x => x.Order)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<WaybillReprint>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }
    }
}

using Data.Context;
using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.Finance;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Finance
{
    public class CashFODCollectionRepository : ICashFODCollectionRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public CashFODCollectionRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddCashFODCollectionAsync(CashFODCollection input)
        {
            await context.Set<CashFODCollection>().AddAsync(input);
            await auditRepository.SaveLog
                (input.OrderId, input.BillNumber, nameof(CashFODCollection), Data.Entities.Helper.ActionEnum.Add, input.CollectorId);
        }
        public async Task UpdateCashFODCollection(CashFODCollection input)
        {
            context.Set<CashFODCollection>().Update(input);
            await auditRepository.SaveLog
                (input.OrderId, input.BillNumber, nameof(CashFODCollection), Data.Entities.Helper.ActionEnum.Update, input.CollectorId);
        }
        public async Task<CashFODCollection> FindCashFODCollectionByIdAsync(Guid billNumber)
        {
            return await context.Set<CashFODCollection>()
                  .Include(x => x.Order)
                  .FirstOrDefaultAsync(x => x.BillNumber == billNumber);
        }

        public async Task<DataPage<CashFODCollection>> GetAllCashFODCollectionsAsync(SearchCriteria input)
        {
            Expression<Func<CashFODCollection, bool>> condition = null;
            condition = a => (a.Order.PickupDate >= input.OrderPickupDateFrom && a.Order.PickupDate <= input.OrderPickupDateTo) &&
                             (input.WaybillNumber == null || !input.WaybillNumber.Any() || input.WaybillNumber.Contains(a.Order.WaybillNumber)) &&
                             (!input.PickupBranchId.HasValue || a.Order.PickupCourier.BranchId == input.PickupBranchId) &&
                             (a.Order.PickupCourier.Code.Contains(input.PickupCourierCode) || string.IsNullOrEmpty(input.PickupCourierCode)) &&
                            (!input.CollectionStatus.HasValue || a.CashFODCollectionStatus == input.CollectionStatus);

            var totalCount = await context.Set<CashFODCollection>().Where(condition).CountAsync();

            var data = await context.Set<CashFODCollection>()
                            .Include(x => x.Order)
                            .ThenInclude(x => x.PickupCourier)
                            .ThenInclude(x => x.Branch)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<CashFODCollection>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }
    }
}

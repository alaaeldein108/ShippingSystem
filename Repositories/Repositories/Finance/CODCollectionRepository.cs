using Data.Context;
using Data.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.Finance;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Finance
{
    public class CODCollectionRepository : ICODCollectionRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public CODCollectionRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddCODCollectionAsync(CODCollection input)
        {
            await context.Set<CODCollection>().AddAsync(input);
            await auditRepository.SaveLog
            (input.OrderId, input.BillNumber, nameof(CODCollection), Data.Entities.Helper.ActionEnum.Add, input.CollectorId);
        }

        public async Task<CODCollection> FindCODCollectionByIdAsync(Guid billNumber)
        {
            return await context.Set<CODCollection>()
                 .Include(x => x.Order)
                 .FirstOrDefaultAsync(x => x.BillNumber == billNumber);
        }

        public async Task<DataPage<CODCollection>> GetAllCODCollectionsAsync(SearchCriteria input)
        {
            Expression<Func<CODCollection, bool>> condition = null;
            condition = a => (a.Order.SigningDate >= input.OrderSignDateFrom && a.Order.SigningDate <= input.OrderSignDateTo) &&
                             (input.WaybillNumber == null || !input.WaybillNumber.Any() || input.WaybillNumber.Contains(a.Order.WaybillNumber)) &&
                             (!input.SignBranchId.HasValue || a.Order.SigningCourier.BranchId == input.SignBranchId) &&
                             (a.Order.SigningCourier.Code.Contains(input.SigningCourierCode) || string.IsNullOrEmpty(input.SigningCourierCode)) &&
                            (!input.CollectionStatus.HasValue || a.CODCollectionStatus == input.CollectionStatus);

            var totalCount = await context.Set<CODCollection>().Where(condition).CountAsync();

            var data = await context.Set<CODCollection>()
                            .Include(x => x.Order)
                            .ThenInclude(x => x.SigningCourier)
                            .ThenInclude(x => x.Branch)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<CODCollection>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public async Task UpdateCODCollection(CODCollection input)
        {
            context.Set<CODCollection>().Update(input);
            await auditRepository.SaveLog
            (input.OrderId, input.BillNumber, nameof(CODCollection), Data.Entities.Helper.ActionEnum.Update, input.CollectorId);
        }
    }
}

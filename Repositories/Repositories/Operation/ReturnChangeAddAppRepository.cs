using Data.Context;
using Data.Entities.Operation.Return_ChangeAdd;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class ReturnChangeAddAppRepository : IReturnChangeAddAppRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public ReturnChangeAddAppRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddReturnChangeAddApplicationAsync(ReturnChangeAddApp input)
        {
            await context.Set<ReturnChangeAddApp>().AddAsync(input);
            await auditRepository.SaveLog
            (input.OrderNumber, null, nameof(ReturnChangeAddApp), Data.Entities.Helper.ActionEnum.Add, input.RegisterId);
        }

        public async Task<ReturnChangeAddApp> FindReturnChangeAddApplicationByIdAsync(Guid id)
        {
            return await context.Set<ReturnChangeAddApp>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DataPage<ReturnChangeAddApp>> GetAllReturnChangeAddApplicationsAsync(SearchCriteria input)
        {
            Expression<Func<ReturnChangeAddApp, bool>> condition = null;
            condition = a => (input.WaybillNumber == null || !input.WaybillNumber.Any() || input.WaybillNumber.Contains(a.Order.WaybillNumber)) &&
                            (a.ApplyingTime >= input.RegisterTimeFrom && a.ApplyingTime <= input.RegisterTimeTo) &&
                            (a.ReviewedTime >= input.RegisterTimeFrom && a.ReviewedTime <= input.RegisterTimeTo) &&
                             (!input.RegisterBranchId.HasValue || a.Register.BranchId == input.RegisterBranchId) &&
                             (a.Register.Code.Contains(input.RegisterCode) || string.IsNullOrEmpty(input.RegisterCode)) &&
                             (a.Register.Code.Contains(input.AuditorCode) || string.IsNullOrEmpty(input.AuditorCode)) &&
                             (!input.PickupBranchId.HasValue || a.Order.PickupCourier.BranchId == input.PickupBranchId) &&
                            (!input.ApplicationType.HasValue || a.ApplicationType == input.ApplicationType) &&
                            (!input.AppStatus.HasValue || a.AppStatus == input.AppStatus);

            var totalCount = await context.Set<ReturnChangeAddApp>().Where(condition).CountAsync();

            var data = await context.Set<ReturnChangeAddApp>()
                            .Include(x => x.Order)
                            .ThenInclude(x => x.PickupCourier)
                            .Include(x => x.Register)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<ReturnChangeAddApp>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public async Task UpdateReturnChangeAddApplication(ReturnChangeAddApp input)
        {
            context.Set<ReturnChangeAddApp>().Update(input);
            await auditRepository.SaveLog
            (input.OrderNumber, null, nameof(ReturnChangeAddApp), Data.Entities.Helper.ActionEnum.Update, input.AuditorId);
        }

    }
}

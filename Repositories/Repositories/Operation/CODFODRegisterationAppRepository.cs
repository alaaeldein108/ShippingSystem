using Data.Context;
using Data.Entities.Operation.COD_FOD_Adjustment;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class CODFODRegisterationAppRepository : ICODFODRegistrationAppRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public CODFODRegisterationAppRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddCODFODApplicationAsync(CODFODAdjustmentApp input)
        {
            await context.Set<CODFODAdjustmentApp>().AddAsync(input);
            await auditRepository.SaveLog
            (input.OrderNumber, input.Id, nameof(CODFODAdjustmentApp), Data.Entities.Helper.ActionEnum.Add, input.RegisterId);
        }
        public async Task UpdateCODFODApplication(CODFODAdjustmentApp input)
        {
            context.Set<CODFODAdjustmentApp>().Update(input);
            await auditRepository.SaveLog
            (input.OrderNumber, input.Id, nameof(CODFODAdjustmentApp), Data.Entities.Helper.ActionEnum.Update, input.AuditorId);
        }

        public async Task<CODFODAdjustmentApp> FindCODFODApplicationByIdAsync(Guid id)
        {
            return await context.Set<CODFODAdjustmentApp>().FindAsync(id);
        }

        public async Task<DataPage<CODFODAdjustmentApp>> GetAllCODFODApplicationsAsync(SearchCriteria input)
        {
            Expression<Func<CODFODAdjustmentApp, bool>> condition = null;
            condition = a => (input.WaybillNumber == null || !input.WaybillNumber.Any() || input.WaybillNumber.Contains(a.Order.WaybillNumber)) &&
                            (a.RegisterTime >= input.RegisterTimeFrom && a.RegisterTime <= input.RegisterTimeTo) &&
                             (!input.RegisterBranchId.HasValue || a.Register.BranchId == input.RegisterBranchId) &&
                            (!input.ConfirmStatus.HasValue || a.ConfirmStatus == input.ConfirmStatus);

            var totalCount = await context.Set<CODFODAdjustmentApp>().Where(condition).CountAsync();

            var data = await context.Set<CODFODAdjustmentApp>()
                            .Include(x => x.Order)
                            .Include(x => x.Register)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<CODFODAdjustmentApp>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }
    }
}

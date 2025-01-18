using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.CustomerService
{
    public class AbnormalRepository : IAbnormalRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public AbnormalRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddAbnormalAsync(Abnormal input)
        {
            await context.Set<Abnormal>().AddAsync(input);
            await auditRepository.SaveLog
                (input.OrderNumber, input.Number, nameof(Abnormal), Data.Entities.Helper.ActionEnum.Add, input.RegisterId);
        }
        public async Task UpdateAbnormal(Abnormal input)
        {
            context.Set<Abnormal>().Update(input);
            await auditRepository.SaveLog
               (input.OrderNumber, input.Number, nameof(Abnormal), Data.Entities.Helper.ActionEnum.Update, input.RegisterId);
        }

        public async Task<DataPage<Abnormal>> GetAllAbnormalsAsync(SearchCriteria input)
        {
            Expression<Func<Abnormal, bool>> condition = null;
            condition = a => (a.RegisterTime >= input.RegisterTimeFrom && a.RegisterTime <= input.RegisterTimeTo) &&
                             (input.WaybillNumber == null || !input.WaybillNumber.Any() || input.WaybillNumber.Contains(a.Order.WaybillNumber)) &&
                            (!input.AbnormalMainReasonId.HasValue || a.AbnormalSubReason.MainReason.Id == input.AbnormalMainReasonId) &&
                            (!input.AbnormalSubReasonId.HasValue || a.AbnormalSubReasonId == input.AbnormalSubReasonId) &&
                            (!input.RegisterBranchId.HasValue || a.Register.BranchId == input.RegisterBranchId) &&
                            (!input.PickupBranchId.HasValue || a.Order.PickupCourier.BranchId == input.PickupBranchId) &&
                            (string.IsNullOrEmpty(input.ClientId) || a.Order.Client.ClientCode == input.ClientId) &&
                            (a.Register.Code.Contains(input.RegisterCode) || string.IsNullOrEmpty(input.RegisterCode));


            var totalCount = await context.Set<Abnormal>().Where(condition).CountAsync();

            var data = await context.Set<Abnormal>()
                            .Where(condition)
                            .Include(a => a.AbnormalSubReason)
                            .ThenInclude(a => a.MainReason)
                            .Include(a => a.Order)
                            .ThenInclude(a => a.Client)
                            .Include(x => x.Order)
                            .ThenInclude(x => x.OrderScans)
                            .Include(x => x.Order)
                            .ThenInclude(x => x.PickupCourier)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<Abnormal>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public async Task<Abnormal> FindAbnormalById(Guid Number)
        {
            return await context.Set<Abnormal>()
                                .Include(a => a.AbnormalSubReason)
                                .ThenInclude(a => a.MainReason)
                                .Include(a => a.Order)
                                .ThenInclude(a => a.Client)
                                .Include(x => x.Order)
                                .ThenInclude(x => x.OrderScans)
                                .Include(x => x.Order)
                                .ThenInclude(x => x.PickupCourier)
                                .FirstOrDefaultAsync(x => x.Number == Number);
        }
    }
}

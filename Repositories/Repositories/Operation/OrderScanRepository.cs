using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.Operation;

namespace Repositories.Repositories.Operation
{
    public class OrderScanRepository : IOrderScanRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public OrderScanRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddOrderScanAsync(OrderScan input)
        {
            await context.Set<OrderScan>().AddAsync(input);
            await auditRepository.SaveLog
            (input.OrderNumber, null, nameof(OrderScan), Data.Entities.Helper.ActionEnum.Add, input.ScannerId);
        }

        public async Task DeleteOrderScan(OrderScan input)
        {
            context.Set<OrderScan>().Remove(input);
            await auditRepository.SaveLog
           (input.OrderNumber, null, nameof(OrderScan), Data.Entities.Helper.ActionEnum.Delete, input.ScannerId);
        }

        public async Task<IQueryable<OrderScan>> GetAllOrderScansAsync()
        {
            return context.Set<OrderScan>().Include(x => x.Order).Include(x => x.Scan);
        }

        public Task<OrderScan> GetOrderScanByOrderAndScanTypeAsync(Guid OrderId, ScanTypeEnum scanType)
        {
            return context.Set<OrderScan>().Include(x => x.Scan)
                .FirstOrDefaultAsync(x => x.OrderNumber == OrderId
                    && x.Scan.ScanTypeName == scanType);
        }

        public async Task UpdateOrderScan(OrderScan input)
        {
            context.Set<OrderScan>().Update(input);
            await auditRepository.SaveLog
           (input.OrderNumber, null, nameof(OrderScan), Data.Entities.Helper.ActionEnum.Update, input.ScannerId);
        }
    }
}

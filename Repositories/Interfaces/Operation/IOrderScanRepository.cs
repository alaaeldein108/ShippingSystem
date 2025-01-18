using Data.Entities.Operation;

namespace Repositories.Interfaces.Operation
{
    public interface IOrderScanRepository
    {
        Task AddOrderScanAsync(OrderScan input);
        Task UpdateOrderScan(OrderScan input);
        Task DeleteOrderScan(OrderScan input);
        Task<OrderScan> GetOrderScanByOrderAndScanTypeAsync(Guid OrderId, ScanTypeEnum scanType);
        Task<IQueryable<OrderScan>> GetAllOrderScansAsync();
    }
}

using Data.Entities.Operation;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order input);
        Task UpdateOrder(Order input);
        Task<Order> FindOrderByIdAsync(Guid id);
        Task<DataPage<Order>> GetAllOrdersAsync(SearchCriteria input);
    }
}

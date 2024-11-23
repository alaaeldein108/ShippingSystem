using Data.Entities.Operation;
using Data.Entities.Operation.COD_FOD_Adjustment;
using Data.Entities.Operation.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order input);
        void UpdateOrder(Order input);
        void DeleteOrder(Order input);
        Task<Order> FindOrderAsync(string id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}

using Data.Entities.Operation;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Operation
{
    public class OrderRepository : IOrderRepository
    {
        public Task AddOrderAsync(Order input)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order input)
        {
            throw new NotImplementedException();
        }

        public Task<Order> FindOrderAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order input)
        {
            throw new NotImplementedException();
        }
    }
}

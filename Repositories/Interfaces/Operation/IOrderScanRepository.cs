using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IOrderScanRepository
    {
        Task AddOrderScanAsync(Order_Scan input);
        void DeleteOrderScan(Order_Scan input);
        Task<IEnumerable<Order_Scan>> GetAllOrderScansAsync(string wabillNumber);
    }
}

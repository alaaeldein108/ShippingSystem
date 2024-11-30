using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Operation
{
    public class OrderScanRepository : IOrderScanRepository
    {
        private readonly AppDbContext context;

        public OrderScanRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddOrderScanAsync(Order_Scan input)
        {
            await context.Set<Order_Scan>().AddAsync(input);
        }

        public void DeleteOrderScan(Order_Scan input)
        {
             context.Set<Order_Scan>().Remove(input);
        }

        public async Task<IQueryable<Order_Scan>> GetAllOrderScansAsync()
        {
            return  context.Set<Order_Scan>().Include(x => x.Order);
        }
    }
}

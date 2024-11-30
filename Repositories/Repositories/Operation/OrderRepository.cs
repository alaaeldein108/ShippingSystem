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
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddOrderAsync(Order input)
        {
            await context.Set<Order>().AddAsync(input);
        }

        public void DeleteOrder(Order input)
        {
            context.Set<Order>().Remove(input);
        }

        public async Task<Order> FindOrderByIdAsync(string id)
        {
           return await context.Set<Order>().FirstOrDefaultAsync(x=>x.OrderNumber==id);
        }

        public async Task<IQueryable<Order>> GetAllOrdersAsync()
        {
            return  context.Set<Order>().Include(x=>x.SenderAddress).Include(x=>x.RecieverAddress);
        }

        public void UpdateOrder(Order input)
        {
            context.Set<Order>().Update(input);
        }


    }
}

using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.CustomerService
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext context;

        public TicketRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddTicketAsync(Ticket input)
        {
            await context.Set<Ticket>().AddAsync(input);
        }

        public async Task<Ticket> FindTicketById(string Number)
        {
            return await context.Set<Ticket>().FirstOrDefaultAsync(x => x.Number == Number);
        }

        public async Task<IQueryable<Ticket>> GetAllTicketsAsync()
        {
            return context.Set<Ticket>()
               .Include(x => x.Order)
               .Include(x => x.SubQuestion)
               .ThenInclude(x => x.MainQuestion);
        }

        public void UpdateTicket(Ticket input)
        {
            context.Set<Ticket>().Update(input);
        }
    }
}

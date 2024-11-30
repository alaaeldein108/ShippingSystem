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
    public class TicketReplyRepository : ITicketReplyRepository
    {
        private readonly AppDbContext context;

        public TicketReplyRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddTicketReplyAsync(TicketReply input)
        {
            await context.Set<TicketReply>().AddAsync(input);   
        }

        public async Task<IEnumerable<TicketReply>> GetAllTicketReplyiesByTicketNumberAsync(string ticketNumber)
        {
            return await context.Set<TicketReply>()
              .Where(x => x.TicketNumber == ticketNumber).ToListAsync();
        }
    }
}

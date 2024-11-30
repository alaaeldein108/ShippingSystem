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
    public class TicketAttachmentRepository : ITicketAttachmentRepository
    {
        private readonly AppDbContext context;

        public TicketAttachmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddTicketAttachments(List<TicketAttachements> attachements)
        {
           await context.Set<TicketAttachements>().AddRangeAsync(attachements);
        }

        public async Task<IEnumerable<TicketAttachements>> GetAllTicketAttachmentsByTicketNumberAsync(string ticketNumber)
        {
            return await context.Set<TicketAttachements>()
                .Where(x => x.TicketNumber == ticketNumber).ToListAsync();
        }
    }
}

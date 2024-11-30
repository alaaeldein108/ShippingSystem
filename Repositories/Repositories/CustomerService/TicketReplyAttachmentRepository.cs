using Data.Context;
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
    public class TicketReplyAttachmentRepository : ITicketReplyAttachmentRepository
    {
        private readonly AppDbContext context;

        public TicketReplyAttachmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddTicketReplyAttachments(List<TicketReplyAttachment> attachments)
        {
            await context.Set<TicketReplyAttachment>().AddRangeAsync(attachments);
        }

        public async Task<IEnumerable<TicketReplyAttachment>> GetAllTicketReplyAttachmentsByTicketNumberAsync(string ticketNumber)
        {
            return await context.Set<TicketReplyAttachment>().Include(x=>x.TicketReply).ThenInclude(x=>x.Ticket)
                .Where(x => x.TicketReply.TicketNumber == ticketNumber).ToListAsync() ; 
        }
    }
}

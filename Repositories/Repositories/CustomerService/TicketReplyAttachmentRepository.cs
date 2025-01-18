using Data.Context;
using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;

namespace Repositories.Repositories.CustomerService
{
    public class TicketReplyAttachmentRepository : ITicketReplyAttachmentRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public TicketReplyAttachmentRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }

        public async Task AddTicketReplyAttachments(List<TicketReplyAttachment> attachments, Guid orderNumber, Guid userId)
        {
            await context.Set<TicketReplyAttachment>().AddRangeAsync(attachments);
            await auditRepository.SaveLog
                (orderNumber, null, nameof(TicketReplyAttachment), Data.Entities.Helper.ActionEnum.Add, userId);
        }

        public async Task<IEnumerable<TicketReplyAttachment>> GetAllTicketReplyAttachmentsByTicketNumberAsync(Guid ticketNumber)
        {
            return await context.Set<TicketReplyAttachment>().Include(x => x.TicketReply).ThenInclude(x => x.Ticket)
                .Where(x => x.TicketReply.TicketNumber == ticketNumber).ToListAsync();
        }
    }
}

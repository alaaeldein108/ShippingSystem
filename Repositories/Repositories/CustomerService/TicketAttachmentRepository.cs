using Data.Context;
using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;

namespace Repositories.Repositories.CustomerService
{
    public class TicketAttachmentRepository : ITicketAttachmentRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public TicketAttachmentRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }

        public async Task AddTicketAttachments(List<TicketAttachements> attachements, Guid orderNumber, Guid userId)
        {
            await context.Set<TicketAttachements>().AddRangeAsync(attachements);
            await auditRepository.SaveLog
                (orderNumber, null, nameof(TicketAttachements), Data.Entities.Helper.ActionEnum.Add, userId);
        }

        public async Task<IEnumerable<TicketAttachements>> GetAllTicketAttachmentsByTicketNumberAsync(Guid ticketNumber)
        {
            return await context.Set<TicketAttachements>()
                .Where(x => x.TicketNumber == ticketNumber).ToListAsync();
        }
    }
}

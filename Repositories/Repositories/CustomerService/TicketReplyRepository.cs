using Data.Context;
using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;

namespace Repositories.Repositories.CustomerService
{
    public class TicketReplyRepository : ITicketReplyRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public TicketReplyRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddTicketReplyAsync(TicketReply input)
        {
            await context.Set<TicketReply>().AddAsync(input);
            await auditRepository.SaveLog
                (input.Ticket.OrderNumber, input.Id, nameof(TicketReply), Data.Entities.Helper.ActionEnum.Add, input.ReplierId);
        }

        public async Task<IEnumerable<TicketReply>> GetAllTicketReplyiesByTicketNumberAsync(Guid ticketNumber)
        {
            return await context.Set<TicketReply>()
              .Where(x => x.TicketNumber == ticketNumber).ToListAsync();
        }
    }
}

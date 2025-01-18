using Data.Entities.CustomerService.Ticket;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketReplyRepository
    {
        Task AddTicketReplyAsync(TicketReply input);
        Task<IEnumerable<TicketReply>> GetAllTicketReplyiesByTicketNumberAsync(Guid ticketNumber);
    }
}

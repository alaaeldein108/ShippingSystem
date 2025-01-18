using Data.Entities.CustomerService.Ticket;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketAttachmentRepository
    {
        Task AddTicketAttachments(List<TicketAttachements> attachements, Guid orderNumber, Guid userId);
        Task<IEnumerable<TicketAttachements>> GetAllTicketAttachmentsByTicketNumberAsync(Guid ticketNumber);
    }
}

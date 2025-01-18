using Data.Entities.CustomerService.Ticket;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketReplyAttachmentRepository
    {
        Task AddTicketReplyAttachments(List<TicketReplyAttachment> attachments, Guid orderNumber, Guid userId);
        Task<IEnumerable<TicketReplyAttachment>> GetAllTicketReplyAttachmentsByTicketNumberAsync(Guid ticketNumber);
    }
}

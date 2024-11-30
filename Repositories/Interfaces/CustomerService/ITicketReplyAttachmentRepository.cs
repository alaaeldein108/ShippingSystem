using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketReplyAttachmentRepository
    {
        Task AddTicketReplyAttachments(List<TicketReplyAttachment> attachments);
        Task<IEnumerable<TicketReplyAttachment>> GetAllTicketReplyAttachmentsByTicketNumberAsync(string ticketNumber);
    }
}

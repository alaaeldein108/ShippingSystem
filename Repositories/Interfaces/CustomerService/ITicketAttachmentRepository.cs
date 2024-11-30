using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketAttachmentRepository
    {
        Task AddTicketAttachments(List<TicketAttachements> attachements);
        Task<IEnumerable<TicketAttachements>> GetAllTicketAttachmentsByTicketNumberAsync(string ticketNumber);
    }
}

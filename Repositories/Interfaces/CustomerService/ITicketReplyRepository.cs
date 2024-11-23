using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketReplyRepository
    {
        Task AddTicketReplyAsync(TicketReply input);
        Task<IEnumerable<TicketReply>> GetAllTicketReplyiesAsync(string ticketNumber);
    }
}

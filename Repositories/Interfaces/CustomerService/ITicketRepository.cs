using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketRepository
    {
        Task AddTicketAsync(Ticket input);
        void UpdateTicket(Ticket input);
        Task<Ticket> FindTicketById(string Number);
        Task<IQueryable<Ticket>> GetAllTicketsAsync();
    }
}

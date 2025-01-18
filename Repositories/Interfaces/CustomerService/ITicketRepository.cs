using Data.Entities.CustomerService.Ticket;
using Repositories.Models;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketRepository
    {
        Task AddTicketAsync(Ticket input);
        Task UpdateTicket(Ticket input);
        Task<Ticket> FindTicketById(Guid Number);
        Task<DataPage<Ticket>> GetAllTicketsAsync(SearchCriteria input);
    }
}

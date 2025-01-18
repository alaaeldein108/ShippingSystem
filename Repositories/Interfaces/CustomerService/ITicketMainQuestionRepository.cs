using Data.Entities.CustomerService.Ticket;
using Repositories.Models;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketMainQuestionRepository
    {
        Task AddTicketMainQuestionAsync(TicketMainQuestion input);
        void UpdateTicketMainQuestion(TicketMainQuestion input);
        void DeleteTicketMainQuestion(TicketMainQuestion input);
        Task<TicketMainQuestion> FindTicketMainQuestionAsync(int id);
        Task<DataPage<TicketMainQuestion>> GetAllTicketMainQuestionsAsync(SearchCriteria input);
    }
}

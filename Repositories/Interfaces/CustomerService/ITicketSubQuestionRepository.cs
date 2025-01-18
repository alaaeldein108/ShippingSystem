using Data.Entities.CustomerService.Ticket;
using Repositories.Models;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketSubQuestionRepository
    {
        Task AddTicketSubQuestionAsync(TicketSubQuestion input);
        void UpdateTicketSubQuestion(TicketSubQuestion input);
        void DeleteTicketSubQuestion(TicketSubQuestion input);
        Task<TicketSubQuestion> FindTicketSubQuestionAsync(int id);
        Task<DataPage<TicketSubQuestion>> GetAllTicketSubQuestionsAsync(SearchCriteria input);
    }
}

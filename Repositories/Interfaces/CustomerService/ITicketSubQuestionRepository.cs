using Data.Entities.CustomerService.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketSubQuestionRepository
    {
        Task AddTicketSubQuestionAsync(TicketSubQuestion input);
        void UpdateTicketSubQuestion(TicketSubQuestion input);
        void DeleteTicketSubQuestion(TicketSubQuestion input);
        Task<TicketSubQuestion> FindTicketSubQuestionAsync(int id);
        Task<IEnumerable<TicketSubQuestion>> GetAllTicketSubQuestionsAsync();
    }
}

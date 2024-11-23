using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface ITicketMainQuestionRepository
    {
        Task AddTicketMainQuestionAsync(TicketMainQuestion input);
        void UpdateTicketMainQuestion(TicketMainQuestion input);
        void DeleteTicketMainQuestion(TicketMainQuestion input);
        Task<TicketMainQuestion> FindTicketMainQuestionAsync(int id);
        Task<IEnumerable<TicketMainQuestion>> GetAllTicketMainQuestionsAsync();
    }
}

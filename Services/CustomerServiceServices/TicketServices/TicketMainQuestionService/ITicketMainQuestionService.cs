using Repositories.Models;
using Services.CustomerServiceServices.TicketServices.TicketMainQuestionService.Dto;

namespace Services.CustomerServiceServices.TicketServices.TicketMainQuestionService
{
    public interface ITicketMainQuestionService
    {
        Task AddTicketMainQuestionAsync(TicketMainQuestionDto input);
        Task UpdateTicketMainQuestion(TicketMainQuestionDto input);
        Task<DataPage<TicketMainQuestionDto>> GetAllTicketMainQuestionAsync(SearchCriteria input);
        Task DeleteTicketMainQuestion(int id);
        Task<TicketMainQuestionDto> GetTicketMainQuestionIdAsync(int id);
    }
}

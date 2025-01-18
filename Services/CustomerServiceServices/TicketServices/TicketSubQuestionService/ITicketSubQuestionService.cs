using Repositories.Models;
using Services.CustomerServiceServices.TicketServices.TicketSubQuestionService.Dto;

namespace Services.CustomerServiceServices.TicketServices.TicketSubQuestionService
{
    public interface ITicketSubQuestionService
    {
        Task AddTicketSubQuestionAsync(TicketSubQuestionDto input);
        Task UpdateTicketSubQuestion(TicketSubQuestionDto input);
        Task<DataPage<TicketSubQuestionDto>> GetAllTicketSubQuestionAsync(SearchCriteria input);
        Task DeleteTicketSubQuestion(int id);
        Task<TicketSubQuestionDto> GetTicketSubQuestionIdAsync(int id);
    }
}

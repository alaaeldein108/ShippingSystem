using Data.Context;
using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.CustomerService;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.CustomerService
{
    public class TicketSubQuestionRepository : ITicketSubQuestionRepository
    {
        private readonly AppDbContext context;

        public TicketSubQuestionRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddTicketSubQuestionAsync(TicketSubQuestion input)
        {
            await context.Set<TicketSubQuestion>().AddAsync(input);
        }

        public void DeleteTicketSubQuestion(TicketSubQuestion input)
        {
            context.Set<TicketSubQuestion>().Remove(input);
        }

        public async Task<TicketSubQuestion> FindTicketSubQuestionAsync(int id)
        {
            return await context.Set<TicketSubQuestion>().FindAsync(id);
        }

        public async Task<DataPage<TicketSubQuestion>> GetAllTicketSubQuestionsAsync(SearchCriteria input)
        {
            Expression<Func<TicketSubQuestion, bool>> condition = null;
            condition = a => (a.Code.Contains(input.TicketSubQuestionCode) || string.IsNullOrEmpty(input.AbnormalSubReasonCode)) &&
                            (a.Code.Contains(input.TicketSubQuestionType) || string.IsNullOrEmpty(input.TicketSubQuestionType)) &&
                            (a.MainQuestion.Code.Contains(input.TicketMainQuestionCode) || string.IsNullOrEmpty(input.TicketMainQuestionCode)) &&
                            (a.MainQuestion.Code.Contains(input.TicketMainQuestionType) || string.IsNullOrEmpty(input.TicketMainQuestionType));

            var totalCount = await context.Set<TicketSubQuestion>().Where(condition).CountAsync();

            var data = await context.Set<TicketSubQuestion>()
                            .Include(x => x.MainQuestion)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<TicketSubQuestion>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateTicketSubQuestion(TicketSubQuestion input)
        {
            context.Set<TicketSubQuestion>().Update(input);
        }
    }
}

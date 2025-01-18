using Data.Context;
using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.CustomerService;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.CustomerService
{
    public class TicketMainQuestionRepository : ITicketMainQuestionRepository
    {
        private readonly AppDbContext context;

        public TicketMainQuestionRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddTicketMainQuestionAsync(TicketMainQuestion input)
        {
            await context.Set<TicketMainQuestion>().AddAsync(input);
        }

        public void DeleteTicketMainQuestion(TicketMainQuestion input)
        {
            context.Set<TicketMainQuestion>().Remove(input);
        }

        public async Task<TicketMainQuestion> FindTicketMainQuestionAsync(int id)
        {
            return await context.Set<TicketMainQuestion>().FindAsync(id);
        }

        public async Task<DataPage<TicketMainQuestion>> GetAllTicketMainQuestionsAsync(SearchCriteria input)
        {
            Expression<Func<TicketMainQuestion, bool>> condition = null;
            condition = a => (a.Code.Contains(input.TicketMainQuestionCode) || string.IsNullOrEmpty(input.TicketMainQuestionCode)) &&
                            (a.Code.Contains(input.TicketMainQuestionType) || string.IsNullOrEmpty(input.TicketMainQuestionType));

            var totalCount = await context.Set<TicketMainQuestion>().Where(condition).CountAsync();

            var data = await context.Set<TicketMainQuestion>()
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<TicketMainQuestion>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateTicketMainQuestion(TicketMainQuestion input)
        {
            context.Set<TicketMainQuestion>().Update(input);
        }
    }
}

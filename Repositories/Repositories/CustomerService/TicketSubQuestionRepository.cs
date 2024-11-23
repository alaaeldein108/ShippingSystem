using Data.Context;
using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<TicketSubQuestion>> GetAllTicketSubQuestionsAsync()
        {
            return await context.Set<TicketSubQuestion>().ToListAsync();
        }

        public void UpdateTicketSubQuestion(TicketSubQuestion input)
        {
            context.Set<TicketSubQuestion>().Update(input);
        }
    }
}

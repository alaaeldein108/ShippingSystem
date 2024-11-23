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

        public async Task<IEnumerable<TicketMainQuestion>> GetAllTicketMainQuestionsAsync()
        {
            return await context.Set<TicketMainQuestion>().ToListAsync();
        }

        public void UpdateTicketMainQuestion(TicketMainQuestion input)
        {
            context.Set<TicketMainQuestion>().Update(input);
        }
    }
}

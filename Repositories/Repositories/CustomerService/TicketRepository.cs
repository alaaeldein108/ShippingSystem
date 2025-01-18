using Data.Context;
using Data.Entities.CustomerService.Ticket;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.CustomerService
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public TicketRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddTicketAsync(Ticket input)
        {
            await context.Set<Ticket>().AddAsync(input);
            await auditRepository.SaveLog
                (input.OrderNumber, input.Number, nameof(Ticket), Data.Entities.Helper.ActionEnum.Add, input.RegisterId);
        }

        public async Task<Ticket> FindTicketById(Guid Number)
        {
            return await context.Set<Ticket>().FirstOrDefaultAsync(x => x.Number == Number);
        }

        public async Task<DataPage<Ticket>> GetAllTicketsAsync(SearchCriteria input)
        {
            Expression<Func<Ticket, bool>> condition = null;
            condition = a => (a.RegisterTime >= input.RegisterTimeFrom && a.RegisterTime <= input.RegisterTimeTo) &&
                             (input.WaybillNumber == null || !input.WaybillNumber.Any() || input.WaybillNumber.Contains(a.Order.WaybillNumber)) &&
                            (!input.TicketMainQuestionId.HasValue || a.SubQuestion.MainQuestionId == input.TicketMainQuestionId) &&
                            (!input.TicketSubQuestionId.HasValue || a.SubQuestionId == input.TicketSubQuestionId) &&
                            (!input.RegisterBranchId.HasValue || a.Register.BranchId == input.RegisterBranchId) &&
                            (!input.PickupBranchId.HasValue || a.Order.PickupCourier.BranchId == input.PickupBranchId) &&
                            (!input.TicketStatus.HasValue || a.TicketStatus == input.TicketStatus) &&
                            (string.IsNullOrEmpty(input.CallerNumber) || a.CallerNumber == input.CallerNumber) &&
                            (a.Register.Code.Contains(input.RegisterCode) || string.IsNullOrEmpty(input.RegisterCode));

            var totalCount = await context.Set<Ticket>().Where(condition).CountAsync();

            var data = await context.Set<Ticket>()
                            .Where(condition)
                            .Include(x => x.Register)
                            .Include(x => x.Order)
                            .Include(a => a.SubQuestion)
                            .ThenInclude(a => a.MainQuestion)
                            .Include(a => a.Order)
                            .ThenInclude(a => a.Client)
                            .Include(x => x.Order)
                            .ThenInclude(x => x.OrderScans)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<Ticket>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());

        }

        public async Task UpdateTicket(Ticket input)
        {
            context.Set<Ticket>().Update(input);
            await auditRepository.SaveLog
                (input.OrderNumber, input.Number, nameof(Ticket), Data.Entities.Helper.ActionEnum.Update, input.RegisterId);
        }

    }
}

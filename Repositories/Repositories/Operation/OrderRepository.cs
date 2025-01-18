using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public OrderRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddOrderAsync(Order input)
        {
            await context.Set<Order>().AddAsync(input);
            await auditRepository.SaveLog
                (input.OrderNumber, input.OrderNumber, nameof(Order), Data.Entities.Helper.ActionEnum.Add, input.ClientCode);
        }
        public async Task UpdateOrder(Order input)
        {
            context.Set<Order>().Update(input);
            await auditRepository.SaveLog
                (input.OrderNumber, input.OrderNumber, nameof(Order), Data.Entities.Helper.ActionEnum.Update, input.ClientCode);
        }
        public async Task<Order> FindOrderByIdAsync(Guid id)
        {
            return await context.Set<Order>().FirstOrDefaultAsync(x => x.OrderNumber == id);
        }

        public async Task<DataPage<Order>> GetAllOrdersAsync(SearchCriteria input)
        {
            Expression<Func<Order, bool>> condition = null;
            condition = a => (input.WaybillNumber == null || !input.WaybillNumber.Any() || input.WaybillNumber.Contains(a.WaybillNumber)) &&
                            (a.PickupDate >= input.OrderPickupDateFrom && a.PickupDate <= input.OrderPickupDateTo) &&
                            (a.SigningDate >= input.OrderSignDateFrom && a.SigningDate <= input.OrderSignDateTo) &&
                            (!input.PickupBranchId.HasValue || a.PickupCourier.BranchId == input.PickupBranchId) &&
                             (!input.AffiliatedAgencyId.HasValue || a.PickupCourier.Branch.AffiliatedAgencyId == input.AffiliatedAgencyId) &&
                             (a.ClientCode.Contains(input.ClientId) || string.IsNullOrEmpty(input.ClientId)) &&
                             (!input.SettlmentMethod.HasValue || a.SettlmentMethod == input.SettlmentMethod) &&
                             (a.PickupCourier.Code.Contains(input.PickupCourierCode) || string.IsNullOrEmpty(input.PickupCourierCode)) &&
                             (!input.Voided.HasValue || a.Voided == input.Voided) &&
                             (!input.ProductTypeId.HasValue || a.ProductTypeId == input.ProductTypeId) &&
                             (!input.IsSigned.HasValue || a.IsSigned == input.IsSigned) &&
                             (a.SenderPhone1.Contains(input.PhoneNumber) || a.SenderPhone2.Contains(input.PhoneNumber)
                             || string.IsNullOrEmpty(input.PhoneNumber)) &&
                             (a.RecieverPhone1.Contains(input.PhoneNumber) || a.RecieverPhone2.Contains(input.PhoneNumber) || string.IsNullOrEmpty(input.PhoneNumber)) &&
                            (a.SenderName.Contains(input.SenderName) || string.IsNullOrEmpty(input.SenderName)) &&
                            (a.OFDTimes >= input.OFDTimesFrom && a.OFDTimes <= input.OFDTimesTo) &&
                             (input.OrderNumber == null || !input.OrderNumber.Any() || input.OrderNumber.Contains(a.OrderNumber)) &&
                             (input.ClientOrderNumber == null || !input.ClientOrderNumber.Any() || input.ClientOrderNumber.Contains(a.ClientOrderNumber)) &&
                            (a.EntryDate >= input.EntryDateFrom && a.EntryDate <= input.EntryDateTo) &&
                            (!input.OrderSource.HasValue || a.OrderSource == input.OrderSource) &&
                            (!input.OrderStatus.HasValue || a.OrderStatus == input.OrderStatus);

            var totalCount = await context.Set<Order>().Where(condition).CountAsync();

            var data = await context.Set<Order>()
                             .Include(x => x.Client)
                             .Include(x => x.ProductType)
                            .Include(x => x.PickupCourier)
                            .ThenInclude(x => x.Branch)
                            .Include(x => x.SenderAddress)
                            .Include(x => x.RecieverAddress)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<Order>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }




    }
}

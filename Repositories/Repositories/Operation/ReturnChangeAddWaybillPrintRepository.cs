using Data.Context;
using Data.Entities.Operation.Return_ChangeAdd;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class ReturnChangeAddWaybillPrintRepository : IReturnChangeAddWaybillPrintRepository
    {
        private readonly AppDbContext context;

        public ReturnChangeAddWaybillPrintRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddReturnChangeAddWaybillPrintAsync(ReturnChangeAddWaybillPrint input)
        {
            await context.Set<ReturnChangeAddWaybillPrint>().AddAsync(input);
        }

        public void DeleteReturnChangeAddWaybillPrintAsync(ReturnChangeAddWaybillPrint input)
        {
            context.Set<ReturnChangeAddWaybillPrint>().Remove(input);
        }

        public async Task<ReturnChangeAddWaybillPrint> FindReturnChangeAddApplicationByIdAsync(Guid id)
        {
            return await context.Set<ReturnChangeAddWaybillPrint>()
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DataPage<ReturnChangeAddWaybillPrint>> GetAllReturnChangeAddApplicationsAsync(SearchCriteria input)
        {
            Expression<Func<ReturnChangeAddWaybillPrint, bool>> condition = null;
            condition = a => (input.WaybillNumber == null || !input.WaybillNumber.Any() ||
                            input.WaybillNumber.Contains(a.ReturnChangeAddApp.Order.WaybillNumber)) &&
                            (!input.RegisterBranchId.HasValue || a.ReturnChangeAddApp.Register.BranchId == input.RegisterBranchId) &&
                            (!input.AuditBranchId.HasValue || a.ReturnChangeAddApp.Auditor.BranchId == input.RegisterBranchId) &&
                            (a.ReturnChangeAddApp.ApplyingTime >= input.RegisterTimeFrom && a.ReturnChangeAddApp.ApplyingTime <= input.RegisterTimeTo) &&
                            (a.ReturnChangeAddApp.ReviewedTime >= input.ReviewedTimeFrom && a.ReturnChangeAddApp.ReviewedTime <= input.ReviewedTimeTo) &&
                            (a.PrintingScanTime >= input.PrintingScanTimeFrom && a.PrintingScanTime <= input.PrintingScanTimeTo) &&
                            (a.Printer.Code.Contains(input.UserId) || string.IsNullOrEmpty(input.UserId)) &&
                            (a.ReturnChangeAddApp.Register.Code.Contains(input.UserId) || string.IsNullOrEmpty(input.UserId)) &&
                             (a.ReturnChangeAddApp.Auditor.Code.Contains(input.AuditorCode) || string.IsNullOrEmpty(input.AuditorCode)) &&
                            (!input.ApplicationType.HasValue || a.ReturnChangeAddApp.ApplicationType == input.ApplicationType) &&
                            (!input.PrintStatus.HasValue || a.PrintStatus == input.PrintStatus);

            var totalCount = await context.Set<ReturnChangeAddWaybillPrint>().Where(condition).CountAsync();

            var data = await context.Set<ReturnChangeAddWaybillPrint>()
                            .Include(x => x.ReturnChangeAddApp)
                            .ThenInclude(x => x.Auditor)
                            .Include(x => x.ReturnChangeAddApp)
                            .ThenInclude(x => x.Order)
                            .Include(x => x.ReturnChangeAddApp)
                            .ThenInclude(x => x.Register)
                            .Include(x => x.ReturnChangeAddApp)
                            .ThenInclude(x => x.Auditor)
                            .Include(x => x.ReturnChangeAddApp)
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<ReturnChangeAddWaybillPrint>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }
    }
}

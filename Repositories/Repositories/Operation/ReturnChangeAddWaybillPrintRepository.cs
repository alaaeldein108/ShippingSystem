using Data.Context;
using Data.Entities.Operation.Return_ChangeAdd;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Operation
{
    public class ReturnChangeAddWaybillPrintRepository : IReturnChangeAddWaybillPrintRepository
    {
        private readonly AppDbContext context;

        public ReturnChangeAddWaybillPrintRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddReturnChangeAddWaybillPrintAsync(Return_ChangeAddWaybillPrint input)
        {
           await context.Set<Return_ChangeAddWaybillPrint>().AddAsync(input);  
        }

        public void DeleteReturnChangeAddWaybillPrintAsync(Return_ChangeAddWaybillPrint input)
        {
             context.Set<Return_ChangeAddWaybillPrint>().Remove(input);
        }

        public async Task<Return_ChangeAddWaybillPrint> FindReturnChangeAddApplicationByIdAsync(string id)
        {
            return await context.Set<Return_ChangeAddWaybillPrint>()
                            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<Return_ChangeAddWaybillPrint>> GetAllReturnChangeAddApplicationsAsync()
        {
            return context.Set<Return_ChangeAddWaybillPrint>();
        }
    }
}

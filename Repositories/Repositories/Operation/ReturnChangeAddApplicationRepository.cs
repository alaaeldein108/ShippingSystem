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
    public class ReturnChangeAddApplicationRepository : IReturnChangeAddApplicationRepository
    {
        private readonly AppDbContext context;

        public ReturnChangeAddApplicationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddReturnChangeAddApplicationAsync(Return_ChangeAdd_App input)
        {
            await context.Set<Return_ChangeAdd_App>().AddAsync(input);
        }

        public async Task<Return_ChangeAdd_App> FindReturnChangeAddApplicationByIdAsync(string id)
        {
            return await context.Set<Return_ChangeAdd_App>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<Return_ChangeAdd_App>> GetAllReturnChangeAddApplicationsAsync()
        {
            return context.Set<Return_ChangeAdd_App>().Include(x => x.Order);
        }

        public void UpdateReturnChangeAddApplication(Return_ChangeAdd_App input)
        {
             context.Set<Return_ChangeAdd_App>().Update(input);
        }

    }
}

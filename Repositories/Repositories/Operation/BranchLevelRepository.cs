using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repositories.Repositories.Operation
{
    public class BranchLevelRepository : IBranchLevelRepository
    {
        private readonly AppDbContext context;

        public BranchLevelRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddBranchLevelAsync(BranchLevel input)
        {
            await context.Set<BranchLevel>().AddAsync(input);
        }

        public void DeleteBranchLevel(BranchLevel input)
        {
            context.Set<BranchLevel>().Remove(input);
        }

        public async Task<BranchLevel> FindBranchLevelByIdAsync(string id)
        {
            return await context.Set<BranchLevel>()
                .FirstOrDefaultAsync(x => x.Code == id);
             
        }

        public async Task<IQueryable<BranchLevel>> GetAllBranchLevelsAsync()
        {
            return context.Set<BranchLevel>();
        }

        public void UpdateBranchLevel(BranchLevel input)
        {
            context.Set<BranchLevel>().Update(input);
        }

    }
}

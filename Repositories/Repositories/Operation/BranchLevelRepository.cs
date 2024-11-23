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

        public async Task<BranchLevel> FindBranchLevelAsync(string name)
        {
            return await context.Set<BranchLevel>()
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BranchLevel>> GetAllBranchLevelsAsync()
        {
            return await context.Set<BranchLevel>().ToListAsync();
        }

        public void UpdateBranchLevel(BranchLevel input)
        {
            context.Set<BranchLevel>().Update(input);
        }
    }
}

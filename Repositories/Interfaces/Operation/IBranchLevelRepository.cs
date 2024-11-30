using Data.Entities.Finance;
using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IBranchLevelRepository
    {
        Task AddBranchLevelAsync(BranchLevel input);
        void UpdateBranchLevel(BranchLevel input);
        void DeleteBranchLevel(BranchLevel input);
        Task<BranchLevel> FindBranchLevelByIdAsync(string id);
        Task<IQueryable<BranchLevel>> GetAllBranchLevelsAsync();
    }
}

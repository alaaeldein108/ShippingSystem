using Data.Entities.Operation;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IBranchLevelRepository
    {
        Task AddBranchLevelAsync(BranchLevel input);
        void UpdateBranchLevel(BranchLevel input);
        void DeleteBranchLevel(BranchLevel input);
        Task<BranchLevel> FindBranchLevelByIdAsync(int id);
        Task<DataPage<BranchLevel>> GetAllBranchLevelsAsync(SearchCriteria input);
    }
}

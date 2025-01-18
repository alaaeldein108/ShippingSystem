using Data.Entities.Operation;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IScanRepository
    {
        Task AddScanAsync(Scan input);
        void UpdateScan(Scan input);
        Task<Scan> FindScanByIdAsync(int code);
        Task<DataPage<Scan>> GetAllScansAsync(SearchCriteria input);
    }
}

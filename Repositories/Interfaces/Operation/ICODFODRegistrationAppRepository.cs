using Data.Entities.Operation.COD_FOD_Adjustment;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface ICODFODRegistrationAppRepository
    {
        Task AddCODFODApplicationAsync(CODFODAdjustmentApp input);
        Task UpdateCODFODApplication(CODFODAdjustmentApp input);
        Task<CODFODAdjustmentApp> FindCODFODApplicationByIdAsync(Guid id);
        Task<DataPage<CODFODAdjustmentApp>> GetAllCODFODApplicationsAsync(SearchCriteria input);
    }
}

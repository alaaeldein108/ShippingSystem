using Data.Entities.Operation.Return_ChangeAdd;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IReturnChangeAddAppRepository
    {
        Task AddReturnChangeAddApplicationAsync(ReturnChangeAddApp input);
        Task UpdateReturnChangeAddApplication(ReturnChangeAddApp input);
        Task<ReturnChangeAddApp> FindReturnChangeAddApplicationByIdAsync(Guid id);
        Task<DataPage<ReturnChangeAddApp>> GetAllReturnChangeAddApplicationsAsync(SearchCriteria input);
    }
}

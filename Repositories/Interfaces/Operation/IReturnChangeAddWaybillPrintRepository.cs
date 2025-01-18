using Data.Entities.Operation.Return_ChangeAdd;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IReturnChangeAddWaybillPrintRepository
    {
        Task AddReturnChangeAddWaybillPrintAsync(ReturnChangeAddWaybillPrint input);
        void DeleteReturnChangeAddWaybillPrintAsync(ReturnChangeAddWaybillPrint input);
        Task<ReturnChangeAddWaybillPrint> FindReturnChangeAddApplicationByIdAsync(Guid id);
        Task<DataPage<ReturnChangeAddWaybillPrint>> GetAllReturnChangeAddApplicationsAsync(SearchCriteria input);
    }
}

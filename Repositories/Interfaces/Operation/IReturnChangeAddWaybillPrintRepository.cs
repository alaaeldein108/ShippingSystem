using Data.Entities.Operation.Return_ChangeAdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IReturnChangeAddWaybillPrintRepository
    {
        Task AddReturnChangeAddWaybillPrintAsync(Return_ChangeAddWaybillPrint input);
        void DeleteReturnChangeAddWaybillPrintAsync(Return_ChangeAddWaybillPrint input);
        Task<Return_ChangeAddWaybillPrint> FindReturnChangeAddApplicationAsync(string id);
        Task<IEnumerable<Return_ChangeAddWaybillPrint>> GetAllReturnChangeAddApplicationsAsync();
    }
}

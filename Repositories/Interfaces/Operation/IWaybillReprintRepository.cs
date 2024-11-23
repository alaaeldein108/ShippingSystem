using Data.Entities.Operation;
using Data.Entities.Operation.Return_ChangeAdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IWaybillReprintRepository
    {
        Task AddWaybillReprintAsync(WaybillReprint input);
        Task<WaybillReprint> FindWaybillReprintAsync(string id);
        Task<IEnumerable<WaybillReprint>> GetAllWaybillReprintsAsync();
    }
}

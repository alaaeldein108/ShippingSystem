using Data.Entities.Operation;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IWaybillReprintRepository
    {
        Task AddWaybillReprintAsync(WaybillReprint input);
        Task<WaybillReprint> FindWaybillReprintByIdAsync(Guid id);
        Task<DataPage<WaybillReprint>> GetAllWaybillReprintsAsync(SearchCriteria input);
    }
}

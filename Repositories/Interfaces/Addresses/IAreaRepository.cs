using Data.Entities.Addresses;
using Repositories.Models;

namespace Repositories.Interfaces.Addresses
{
    public interface IAreaRepository
    {
        Task<Area> GetAreaById(string code);
        Task<DataPage<Area>> GetAllAreaAsync(SearchCriteria input);
    }
}

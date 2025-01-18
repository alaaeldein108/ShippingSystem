using Data.Entities.Finance;
using Repositories.Models;

namespace Repositories.Interfaces.Finance
{
    public interface IZoneRepository
    {
        Task AddZoneAsync(Zone input);
        void UpdateZone(Zone input);
        void DeleteZone(Zone input);
        Task<Zone> FindZoneByIdAsync(int id);
        Task<DataPage<Zone>> GetAllZonesAsync(SearchCriteria input);

    }
}

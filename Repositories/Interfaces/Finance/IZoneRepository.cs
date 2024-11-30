using Data.Entities.CustomerService.Abnormal;
using Data.Entities.Enums;
using Data.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Finance
{
    public interface IZoneRepository
    {
        Task AddZoneAsync(Zone input);
        void UpdateZone(Zone input);
        void DeleteZone(Zone input);
        Task<Zone> FindZoneByIdAsync(int id);
        Task<IQueryable<Zone>> GetAllZonesAsync();
       
    }
}

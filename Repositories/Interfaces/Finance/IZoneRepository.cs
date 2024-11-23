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
        Task<IEnumerable<Zone>> GetAllZonesByNameAsync(string input);
        Task<IEnumerable<Zone>> GetAllZonesByDestinationAsync(string input);
        Task<IEnumerable<Zone>> GetAllZonesByBranchAsync(string input);
        Task<IEnumerable<Zone>> GetAllZonesByTypeAsync(ZoneTypeEnum zoneType);
        Task<IEnumerable<Zone>> GetAllZonesByQuotationTypeAsync(QuotationTypeEnum quotationType);
    }
}

using Repositories.Models;
using Services.FinanceServices.ZoneService.Dto;

namespace Services.FinanceServices.ZoneService
{
    public interface IZoneService
    {
        Task AddZoneAsync(ZoneDto input);
        Task UpdateZone(ZoneDto input);
        Task<DataPage<ZoneDto>> GetAllZonesAsync(ZonePagination input);
        Task DeleteZone(int id);
        Task<ZoneDto> GetZoneIdAsync(int id);
    }
}

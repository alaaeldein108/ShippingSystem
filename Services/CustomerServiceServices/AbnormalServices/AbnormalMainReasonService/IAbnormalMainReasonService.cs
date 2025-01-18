using Repositories.Models;
using Services.CustomerServiceServices.AbnormalServices.AbnormalMainReasonService.Dto;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalMainReasonService
{
    public interface IAbnormalMainReasonService
    {
        Task AddAbnormalMainReasonAsync(AbnormalMainReasonDto input);
        Task UpdateAbnormalMainReason(AbnormalMainReasonDto input);
        Task<DataPage<AbnormalMainReasonDto>> GetAllAbnormalMainReasonAsync(SearchCriteria input);
        Task DeleteAbnormalMainReason(int id);
        Task<AbnormalMainReasonDto> GetAbnormalMainReasonIdAsync(int id);
    }
}

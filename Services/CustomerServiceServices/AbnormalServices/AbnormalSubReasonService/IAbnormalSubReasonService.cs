using Repositories.Models;
using Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService.Dto;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService
{
    public interface IAbnormalSubReasonService
    {
        Task AddAbnormalSubReasonAsync(AbnormalSubReasonDto input);
        Task UpdateAbnormalSubReason(AbnormalSubReasonDto input);
        Task<DataPage<AbnormalSubReasonDto>> GetAllAbnormalSubReasonAsync(SearchCriteria input);
        Task DeleteAbnormalSubReason(int id);
        Task<AbnormalSubReasonDto> GetAbnormalSubReasonIdAsync(int id);
    }
}

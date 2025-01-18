using Data.Entities.CustomerService.Abnormal;
using Repositories.Models;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalMainReasonRepository
    {
        Task AddAbnormalMainReasonAsync(AbnormalMainReason input);
        void UpdateAbnormalMainReason(AbnormalMainReason input);
        void DeleteAbnormalMainReason(AbnormalMainReason input);
        Task<AbnormalMainReason> FindAbnormalMainReasonAsync(int id);
        Task<DataPage<AbnormalMainReason>> GetAllAbnormalMainReasonsAsync(SearchCriteria input);
    }
}

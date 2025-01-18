using Data.Entities.CustomerService.Abnormal;
using Repositories.Models;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalSubReasonRepository
    {
        Task AddAbnormalSubReasonAsync(AbnormalSubReason input);
        void UpdateAbnormalSubReason(AbnormalSubReason input);
        void DeleteAbnormalSubReason(AbnormalSubReason input);
        Task<AbnormalSubReason> FindAbnormalSubReasonAsync(int id);
        Task<DataPage<AbnormalSubReason>> GetAllAbnormalSubReasonsAsync(SearchCriteria input);
    }
}

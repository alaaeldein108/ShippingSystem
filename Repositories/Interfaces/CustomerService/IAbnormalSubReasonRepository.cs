using Data.Entities.CustomerService.Abnormal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalSubReasonRepository
    {
        Task AddAbnormalSubReasonAsync(AbnormalSubReason input);
        void UpdateAbnormalSubReason(AbnormalSubReason input);
        void DeleteAbnormalSubReason(AbnormalSubReason input);
        Task<AbnormalSubReason> FindAbnormalSubReasonAsync(int id);
        Task<IEnumerable<AbnormalSubReason>> GetAllAbnormalSubReasonsAsync();
    }
}

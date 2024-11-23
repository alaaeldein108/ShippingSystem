using Data.Entities.Addresses;
using Data.Entities.CustomerService.Abnormal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalMainReasonRepository
    {
        Task AddAbnormalMainReasonAsync(AbnormalMainReason input);
        void UpdateAbnormalMainReason(AbnormalMainReason input);
        void DeleteAbnormalMainReason(AbnormalMainReason input);
        Task<AbnormalMainReason> FindAbnormalMainReasonAsync(int id);
        Task<IEnumerable<AbnormalMainReason>> GetAllAbnormalMainReasonsAsync();
    }
}

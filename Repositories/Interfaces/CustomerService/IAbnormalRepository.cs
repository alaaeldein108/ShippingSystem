using Data.Entities.CustomerService.Abnormal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalRepository
    {
        Task AddAbnormalAsync(Abnormal input);
        void UpdateAbnormalAsync(Abnormal input);
        Task<IEnumerable<Abnormal>> GetAllAbnormalsByWaybillAsync(string waybillNumber);
    }
}

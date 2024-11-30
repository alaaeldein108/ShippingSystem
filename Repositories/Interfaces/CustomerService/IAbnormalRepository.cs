using Data.Entities.CustomerService.Abnormal;
using Data.Entities.Operation;
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
        void UpdateAbnormal(Abnormal input);
        Task<Abnormal> FindAbnormalById(string Number);
        Task<IQueryable<Abnormal>> GetAllAbnormalsAsync();
    }
}

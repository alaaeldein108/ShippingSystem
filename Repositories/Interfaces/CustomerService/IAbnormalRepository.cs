using Data.Entities.CustomerService.Abnormal;
using Repositories.Models;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalRepository
    {
        Task AddAbnormalAsync(Abnormal input);
        Task UpdateAbnormal(Abnormal input);
        Task<Abnormal> FindAbnormalById(Guid Number);
        Task<DataPage<Abnormal>> GetAllAbnormalsAsync(SearchCriteria input);
    }
}

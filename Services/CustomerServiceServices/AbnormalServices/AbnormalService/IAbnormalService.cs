using Repositories.Models;
using Services.CustomerServiceServices.AbnormalServices.AbnormalService.Dto;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalService
{
    public interface IAbnormalService
    {
        Task AddAbnormalAsync(AbnormalDto input, Guid creatorId);
        Task UpdateAbnormal(AbnormalDto input, Guid creatorId);
        Task<GetAbnormalDto> FindAbnormalById(Guid Number);
        Task<DataPage<GetAbnormalDto>> GetAllAbnormalsAsync(SearchCriteria input);
    }
}

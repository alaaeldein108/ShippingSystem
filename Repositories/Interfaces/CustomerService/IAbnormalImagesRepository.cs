using Data.Entities.CustomerService.Abnormal;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalImagesRepository
    {
        Task AddAbnormalImages(List<AbnormalImages> images, Guid orderNumber, Guid userId);
        Task<IEnumerable<AbnormalImages>> GetAllAbnormalImagesByAbnormalNumberAsync(Guid abnormalNumber);
    }
}

using Data.Entities.CustomerService.Abnormal;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalReplyImageRepository
    {
        Task AddAbnormalReplyImages(List<AbnormalReplyImages> images, Guid orderNumber, Guid userId);
        Task<IEnumerable<AbnormalReplyImages>> GetAllAbnormalReplyImagesByAbnormalNumberAsync(Guid abnormalNumber);
    }
}

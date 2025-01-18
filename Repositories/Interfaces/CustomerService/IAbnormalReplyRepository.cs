using Data.Entities.CustomerService.Abnormal;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalReplyRepository
    {
        Task AddAbnormalReplyAsync(AbnormalReply input);
        Task<IEnumerable<AbnormalReply>> GetAllAbnormalReplyiesByAbnormalNumberAsync(Guid abnormalNumber);
    }
}

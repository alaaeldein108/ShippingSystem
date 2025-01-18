using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;

namespace Repositories.Repositories.CustomerService
{
    public class AbnormalReplyImageRepository : IAbnormalReplyImageRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public AbnormalReplyImageRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddAbnormalReplyImages(List<AbnormalReplyImages> images, Guid orderNumber, Guid userId)
        {
            await context.Set<AbnormalReplyImages>().AddRangeAsync(images);
            await auditRepository.SaveLog
                (orderNumber, null, nameof(AbnormalReplyImages), Data.Entities.Helper.ActionEnum.Add, userId);
        }

        public async Task<IEnumerable<AbnormalReplyImages>> GetAllAbnormalReplyImagesByAbnormalNumberAsync(Guid abnormalNumber)
        {
            return await context.Set<AbnormalReplyImages>().Include(x => x.Reply).ThenInclude(x => x.Abnormal)
                .Where(x => x.Reply.AbnormalNumber == abnormalNumber).ToListAsync();
        }
    }
}

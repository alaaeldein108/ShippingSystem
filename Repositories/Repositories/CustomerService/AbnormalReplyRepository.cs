using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;

namespace Repositories.Repositories.CustomerService
{
    public class AbnormalReplyRepository : IAbnormalReplyRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public AbnormalReplyRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddAbnormalReplyAsync(AbnormalReply input)
        {
            await context.Set<AbnormalReply>().AddAsync(input);
            await auditRepository.SaveLog
            (input.Abnormal.OrderNumber, input.Id, nameof(AbnormalReply), Data.Entities.Helper.ActionEnum.Add, input.ReplierId);
        }

        public async Task<IEnumerable<AbnormalReply>> GetAllAbnormalReplyiesByAbnormalNumberAsync(Guid abnormalNumber)
        {
            return await context.Set<AbnormalReply>()
                .Include(x => x.ReplyImages).Include(x => x.Replier)
                .Where(x => x.AbnormalNumber == abnormalNumber).ToListAsync();
        }
    }
}

using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;

namespace Repositories.Repositories.CustomerService
{
    public class AbnormalImagesRepository : IAbnormalImagesRepository
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

        public AbnormalImagesRepository(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
        }
        public async Task AddAbnormalImages(List<AbnormalImages> images, Guid orderNumber, Guid userId)
        {
            await context.Set<AbnormalImages>().AddRangeAsync(images);
            await auditRepository.SaveLog
                (orderNumber, null, nameof(AbnormalImages), Data.Entities.Helper.ActionEnum.Add, userId);
        }

        public async Task<IEnumerable<AbnormalImages>> GetAllAbnormalImagesByAbnormalNumberAsync(Guid abnormalNumber)
        {
            var abnormalImages = await context.Set<AbnormalImages>()
                            .Where(x => x.AbnormalNumber == abnormalNumber).ToListAsync();

            return abnormalImages;
        }
    }
}

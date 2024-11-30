using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Interfaces.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.CustomerService
{
    public class AbnormalImagesRepository : IAbnormalImagesRepository
    {
        private readonly AppDbContext context;

        public AbnormalImagesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAbnormalImages(List<AbnormalImages> images)
        {
            await context.Set<AbnormalImages>().AddRangeAsync(images);
        }

        public async Task<IEnumerable<AbnormalImages>> GetAllAbnormalImagesByAbnormalNumberAsync(string abnormalNumber)
        {
            var abnormalImages = await context.Set<AbnormalImages>()
                            .Where(x => x.AbnormalNumber == abnormalNumber).ToListAsync();

            return abnormalImages;
        }
    }
}

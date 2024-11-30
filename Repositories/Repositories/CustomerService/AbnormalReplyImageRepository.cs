using Data.Context;
using Data.Entities.CustomerService.Abnormal;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.CustomerService
{
    public class AbnormalReplyImageRepository : IAbnormalReplyImageRepository
    {
        private readonly AppDbContext context;

        public AbnormalReplyImageRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAbnormalReplyImages(List<AbnormalReplyImages> images)
        {
            await context.Set<AbnormalReplyImages>().AddRangeAsync(images);
        }

        public async Task<IEnumerable<AbnormalReplyImages>> GetAllAbnormalReplyImagesByAbnormalNumberAsync(string abnormalNumber)
        {
            return await context.Set<AbnormalReplyImages>().Include(x=>x.Reply).ThenInclude(x=>x.Abnormal)
                .Where(x => x.Reply.AbnormalNumber == abnormalNumber).ToListAsync();
        }
    }
}

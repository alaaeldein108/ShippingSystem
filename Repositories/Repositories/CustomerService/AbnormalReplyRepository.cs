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
    public class AbnormalReplyRepository : IAbnormalReplyRepository
    {
        private readonly AppDbContext context;

        public AbnormalReplyRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAbnormalReplyAsync(AbnormalReply input)
        {
            await context.Set<AbnormalReply>().AddAsync(input);
        }

        public async Task<IEnumerable<AbnormalReply>> GetAllAbnormalReplyiesByAbnormalNumberAsync(string abnormalNumber)
        {
            return await context.Set<AbnormalReply>()
                .Where(x => x.AbnormalNumber == abnormalNumber).ToListAsync();
        }
    }
}

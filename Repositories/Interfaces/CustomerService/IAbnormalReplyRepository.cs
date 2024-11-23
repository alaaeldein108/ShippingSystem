using Data.Entities.CustomerService.Abnormal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalReplyRepository
    {
        Task AddAbnormalReplyAsync(AbnormalReply input);
        Task<IEnumerable<AbnormalReply>> GetAllAbnormalReplyiesAsync(string abnormalNumber);
    }
}

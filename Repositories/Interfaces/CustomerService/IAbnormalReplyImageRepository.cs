using Data.Entities.CustomerService.Abnormal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalReplyImageRepository
    {
        Task AddAbnormalReplyImages(List<AbnormalReplyImages> images);
        Task<IEnumerable<AbnormalReplyImages>> GetAllAbnormalReplyImagesByAbnormalNumberAsync(string abnormalNumber);
    }
}

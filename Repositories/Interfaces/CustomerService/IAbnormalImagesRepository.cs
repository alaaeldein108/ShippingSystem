using Data.Entities.CustomerService.Abnormal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.CustomerService
{
    public interface IAbnormalImagesRepository
    {
        Task AddAbnormalImages(List<AbnormalImages> images);
        Task<IEnumerable<AbnormalImages>> GetAllAbnormalImagesByAbnormalNumberAsync(string abnormalNumber);
    }
}

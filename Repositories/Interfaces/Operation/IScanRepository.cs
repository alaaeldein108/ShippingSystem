using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IScanRepository
    {
        Task AddScanAsync(Scan input);
        void UpdateScan(Scan input);
        Task<Scan> FindScanAsync(int code);
        Task<IEnumerable<Scan>> GetAllScansAsync();
    }
}

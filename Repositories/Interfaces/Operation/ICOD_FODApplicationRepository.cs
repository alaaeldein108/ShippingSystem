using Data.Entities.Operation;
using Data.Entities.Operation.COD_FOD_Adjustment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface ICOD_FODApplicationRepository
    {
        Task AddCOD_FODApplicationAsync(COD_FOD_Application input);
        void UpdateCOD_FODApplication(COD_FOD_Application input);
        Task<COD_FOD_Application> FindCOD_FODApplicationByIdAsync(int id);
        Task<IQueryable<COD_FOD_Application>> GetAllCOD_FODApplicationsAsync();
    }
}

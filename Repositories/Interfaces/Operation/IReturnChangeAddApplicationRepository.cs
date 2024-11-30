using Data.Entities.Operation;
using Data.Entities.Operation.Return_ChangeAdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IReturnChangeAddApplicationRepository
    {
        Task AddReturnChangeAddApplicationAsync(Return_ChangeAdd_App input);
        void UpdateReturnChangeAddApplication(Return_ChangeAdd_App input);
        Task<Return_ChangeAdd_App> FindReturnChangeAddApplicationByIdAsync(string id);
        Task<IQueryable<Return_ChangeAdd_App>> GetAllReturnChangeAddApplicationsAsync();
    }
}

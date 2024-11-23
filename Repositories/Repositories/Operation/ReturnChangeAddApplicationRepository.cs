using Data.Entities.Operation.Return_ChangeAdd;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Operation
{
    public class ReturnChangeAddApplicationRepository : IReturnChangeAddApplicationRepository
    {
        public Task AddReturnChangeAddApplicationAsync(Return_ChangeAdd_App input)
        {
            throw new NotImplementedException();
        }

        public void DeleteReturnChangeAddApplication(Return_ChangeAdd_App input)
        {
            throw new NotImplementedException();
        }

        public Task<Return_ChangeAdd_App> FindReturnChangeAddApplicationAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Return_ChangeAdd_App>> GetAllReturnChangeAddApplicationsAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateReturnChangeAddApplication(Return_ChangeAdd_App input)
        {
            throw new NotImplementedException();
        }
    }
}

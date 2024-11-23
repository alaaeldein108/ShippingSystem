using Data.Entities.Operation;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Operation
{
    public class WaybillReprintRepository : IWaybillReprintRepository
    {
        public Task AddWaybillReprintAsync(WaybillReprint input)
        {
            throw new NotImplementedException();
        }

        public Task<WaybillReprint> FindWaybillReprintAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WaybillReprint>> GetAllWaybillReprintsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

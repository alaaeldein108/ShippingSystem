using Data.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Finance
{
    public interface ICODCollectionRepository
    {
        Task AddCODCollectionAsync(COD_Collection input);
        void UpdateCODCollection(COD_Collection input);
        Task<COD_Collection> FindCODCollectionByWaybillAsync(string waybillNumber);
    }
}

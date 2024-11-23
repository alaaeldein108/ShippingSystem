using Data.Entities.CustomerService.Ticket;
using Data.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Finance
{
    public interface ICash_FODCollectionRepository
    {
        Task AddCash_FODCollectionAsync(Cash_FODCollection input);
        void UpdateCash_FODCollection(Cash_FODCollection input);
        Task<Cash_FODCollection> FindCash_FODCollectionByWaybillAsync(string waybillNumber);
    }
}

using Data.Entities.CustomerService.Abnormal;
using Data.Entities.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Finance
{
    public interface IQuotationRepository
    {
        Task AddQuotationAsync(Quotation input);
        void UpdateQuotation(Quotation input);
        Task<Quotation> FindQuotationByIdAsync(int id);
        Task<IQueryable<Quotation>> GetAllQuotationsAsync();
       
    }
}

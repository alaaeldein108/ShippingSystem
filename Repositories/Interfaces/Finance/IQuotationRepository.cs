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
        Task<IEnumerable<Quotation>> GetAllQuotationsByBranchAsync(string branchCode);
        Task<IEnumerable<Quotation>> GetAllQuotationsByValidationTimeAsync(DateTime startTime, DateTime endTime);
        Task<IEnumerable<Quotation>> GetAllQuotationsByAuditingAsync(AuditingEnum auditing);
        Task<IEnumerable<Quotation>> GetAllQuotationsByProductTypeAsync(string productTypeCode);
    }
}

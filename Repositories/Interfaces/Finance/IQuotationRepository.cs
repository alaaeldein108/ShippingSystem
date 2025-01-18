using Data.Entities.Finance;
using Repositories.Models;

namespace Repositories.Interfaces.Finance
{
    public interface IQuotationRepository
    {
        Task AddQuotationAsync(Quotation input);
        void UpdateQuotation(Quotation input);
        Task<Quotation> FindQuotationByIdAsync(int id);
        Task<DataPage<Quotation>> GetAllQuotationsAsync(SearchCriteria input);

    }
}

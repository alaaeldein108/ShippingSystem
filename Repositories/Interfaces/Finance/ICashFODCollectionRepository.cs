using Data.Entities.Finance;
using Repositories.Models;

namespace Repositories.Interfaces.Finance
{
    public interface ICashFODCollectionRepository
    {
        Task AddCashFODCollectionAsync(CashFODCollection input);
        Task UpdateCashFODCollection(CashFODCollection input);
        Task<CashFODCollection> FindCashFODCollectionByIdAsync(Guid billNumber);
        Task<DataPage<CashFODCollection>> GetAllCashFODCollectionsAsync(SearchCriteria input);

    }
}

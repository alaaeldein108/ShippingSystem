using Data.Entities.Finance;
using Repositories.Models;

namespace Repositories.Interfaces.Finance
{
    public interface ICODCollectionRepository
    {
        Task AddCODCollectionAsync(CODCollection input);
        Task UpdateCODCollection(CODCollection input);
        Task<CODCollection> FindCODCollectionByIdAsync(Guid billNumber);
        Task<DataPage<CODCollection>> GetAllCODCollectionsAsync(SearchCriteria input);

    }
}

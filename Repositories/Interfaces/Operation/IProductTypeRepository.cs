using Data.Entities.Operation;
using Repositories.Models;

namespace Repositories.Interfaces.Operation
{
    public interface IProductTypeRepository
    {
        Task AddProductTypeAsync(ProductType input);
        void UpdateProductType(ProductType input);
        void DeleteProductType(ProductType input);
        Task<ProductType> FindProductTypeByIdAsync(int code);
        Task<DataPage<ProductType>> GetAllProductTypesAsync(SearchCriteria input);
    }
}

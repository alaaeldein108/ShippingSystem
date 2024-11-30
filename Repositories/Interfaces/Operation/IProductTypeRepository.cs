using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces.Operation
{
    public interface IProductTypeRepository
    {
        Task AddProductTypeAsync(ProductType input);
        void UpdateProductType(ProductType input);
        void DeleteProductType(ProductType input);
        Task<ProductType> FindProductTypeByIdAsync(string code);
        Task<IEnumerable<ProductType>> GetAllProductTypesAsync();
    }
}

using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using Repositories.Models;
using System.Linq.Expressions;

namespace Repositories.Repositories.Operation
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly AppDbContext context;

        public ProductTypeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddProductTypeAsync(ProductType input)
        {
            await context.Set<ProductType>().AddAsync(input);
        }

        public void DeleteProductType(ProductType input)
        {
            context.Set<ProductType>().Remove(input);
        }

        public async Task<ProductType> FindProductTypeByIdAsync(int id)
        {
            return await context.Set<ProductType>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DataPage<ProductType>> GetAllProductTypesAsync(SearchCriteria input)
        {
            Expression<Func<ProductType, bool>> condition = null;
            condition = a => (!input.ProductTypeId.HasValue || a.Id == input.ProductTypeId);


            var totalCount = await context.Set<ProductType>().Where(condition).CountAsync();

            var data = await context.Set<ProductType>()
                            .Where(condition)
                            .Skip((input.PageIndex - 1) * input.PageSize)
                            .Take(input.PageSize)
                            .ToListAsync();

            return new DataPage<ProductType>(input.PageIndex, input.PageSize, totalCount, data.AsQueryable());
        }

        public void UpdateProductType(ProductType input)
        {
            context.Set<ProductType>().Update(input);
        }
    }
}

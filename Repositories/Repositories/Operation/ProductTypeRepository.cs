using Data.Context;
using Data.Entities.Operation;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public async Task<ProductType> FindProductTypeByIdAsync(string code)
        {
            return await context.Set<ProductType>()
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypesAsync()
        {
            return await context.Set<ProductType>().ToListAsync();    
        }

        public void UpdateProductType(ProductType input)
        {
            context.Set<ProductType>().Update(input);
        }
    }
}

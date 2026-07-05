using ProductManagement.Domain.Contract.Products;

namespace ProductManagement.Persistance.Repositories
{
    public class ProductEventRepository(IDbContext context) : IProductEventRepository
    {
        public async Task Persist(ProductEventModel happen)
        {
            await context.DbSet<ProductEventModel>().AddAsync(happen);
        }
    }
}

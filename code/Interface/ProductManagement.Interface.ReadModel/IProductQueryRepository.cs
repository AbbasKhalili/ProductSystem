using ProductManagement.Domain.Products;
using Shared.Domain;

namespace ProductManagement.Interface.ReadModel
{
    public interface IProductQueryRepository : IRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Product>> GetAllAsync();
    }
}

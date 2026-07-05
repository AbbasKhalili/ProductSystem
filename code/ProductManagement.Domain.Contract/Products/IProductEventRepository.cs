using Shared.Domain;

namespace ProductManagement.Domain.Contract.Products
{
    public interface IProductEventRepository : IRepository
    {
        Task Persist(ProductEventModel happen);
    }
}

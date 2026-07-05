using ProductManagement.Domain.Products;
using ProductManagement.Interface.Contracts.Products.DTOs;

namespace ProductManagement.Interface.ReadModel.Mappers
{
    public static class ProductMappers
    {
        public static List<ProductDto> Map(IReadOnlyList<Product> list)
        {
            return [.. list.Select(Map)];
        }

        public static ProductDto Map(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity
            };
        }
    }
}

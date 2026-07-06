using ProductManagement.Domain.Products;
using ProductManagement.Domain.Products.Exceptions;
using ProductManagement.Interface.Contracts.Products.DTOs;
using ProductManagement.Interface.Contracts.Products.Services;
using ProductManagement.Interface.ReadModel.Mappers;
using Shared.Core.Exceptions;
using Shared.Presentation;

namespace ProductManagement.Interface.ReadModel
{
    public class ProductFacadeQuery(IProductQueryRepository productRepository) : IProductFacadeQuery
    {
        public async Task<JsonResponse<ProductDto>> Get(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            
            Guard<ProductNotFoundException>.AgainstNull(product);

            return JsonResponse<ProductDto>.Success(ProductMappers.Map(product));
        }

        public async Task<JsonResponsePagination<List<ProductDto>>> GetAll(int pageindex, int pagesize)
        {
            var products = await productRepository.GetAllAsync();
            return JsonResponsePagination<List<ProductDto>>.Success(ProductMappers.Map(products), 100, 10, 1);
        }
    }
}

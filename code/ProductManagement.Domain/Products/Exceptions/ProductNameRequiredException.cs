using Shared.Core.Exceptions;

namespace ProductManagement.Domain.Products.Exceptions;

public class ProductNameRequiredException : BusinessException
{
    public ProductNameRequiredException() : base(100) { }
}

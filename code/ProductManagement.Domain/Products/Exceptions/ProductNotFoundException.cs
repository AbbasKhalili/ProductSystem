using Shared.Core.Exceptions;

namespace ProductManagement.Domain.Products.Exceptions;

public class ProductNotFoundException : BusinessException
{
    public ProductNotFoundException() : base(101) { }
}
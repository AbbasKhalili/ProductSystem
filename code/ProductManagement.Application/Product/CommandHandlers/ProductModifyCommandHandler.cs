using ProductManagement.Application.Contracts.Product.Command;
using ProductManagement.Domain.Contract.Products;
using ProductManagement.Domain.Products;
using ProductManagement.Domain.Products.Exceptions;

namespace ProductManagement.Application.Product.CommandHandlers
{
    public class ProductModifyCommandHandler : ProductCommandHandler<ModifyProductCommand, ProductModified>
    {
        public ProductModifyCommandHandler(
            IProductRepository repository, 
            IEventPublisher publisher, 
            IEventListener listener,
            IEventHandler<ProductModified> eventHandler)
            : base(repository, publisher, listener, eventHandler)
        {
        }

        public override async Task Execute(ModifyProductCommand command)
        {
            var product = await Repository.GetByIdAsync(command.Id);

            Guard<ProductNotFoundException>.AgainstNull(product);

            await product.Update(command.Name, command.Description, command.Price, command.StockQuantity, Publisher);
        }
    }
}

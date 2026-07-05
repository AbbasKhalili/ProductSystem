using ProductManagement.Domain.Contract.Products;

namespace ProductManagement.Domain.EventHandlers.ProductEventHandlers
{
    public class ProductCreatedEventHandler : ProductEventsHandlerBase<ProductCreated>
    {
        public ProductCreatedEventHandler(IProductEventRepository eventRepository) : base(eventRepository)
        {
        }

        protected override string DetermineEventType()
        {
            return "Created";
        }
    }
}

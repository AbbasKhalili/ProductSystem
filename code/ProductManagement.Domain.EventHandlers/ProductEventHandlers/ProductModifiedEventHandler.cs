using ProductManagement.Domain.Contract.Products;

namespace ProductManagement.Domain.EventHandlers.ProductEventHandlers
{
    public class ProductModifiedEventHandler : ProductEventsHandlerBase<ProductModified>
    {
        public ProductModifiedEventHandler(IProductEventRepository eventRepository) : base(eventRepository)
        {
        }

        protected override string DetermineEventType()
        {
            return "Modified";
        }
    }
}

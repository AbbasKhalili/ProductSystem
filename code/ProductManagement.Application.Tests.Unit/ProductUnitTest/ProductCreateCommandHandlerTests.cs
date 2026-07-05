using FluentAssertions;
using NSubstitute;
using ProductManagement.Application.Contracts.Product.Command;
using ProductManagement.Application.Product.CommandHandlers;
using ProductManagement.Domain.Contract.Products;
using ProductManagement.Domain.Products.DomainServices;

namespace ProductManagement.Application.Tests.Unit.ProductUnitTest
{
    public class ProductCreateCommandHandlerTests : BaseProductCommandHandlerTests<ProductCreated>
    {
        private readonly ProductCreateCommandHandler _handler;
        public ProductCreateCommandHandlerTests()
        {
            var stockQuantityService = Substitute.For<StockQuantityService>();
            _handler = new ProductCreateCommandHandler(Repository, EventPublisher, EventListener, EventHandler,
                stockQuantityService);
        }

        [Fact]
        public async Task HandleCreate_should_add_Product_to_repository()
        {
            var command = new CreateProductCommand()
            {
                Name = "Lubricant H250 z",
                Description = "descripton of Lubricant H250 z",
                Price = 1000,
                StockQuantity = 100
            };

            await _handler.Execute(command);

            var expected = await CreateExpected();
            await Repository.Received(1)
                .AddAsync(Inquire.That<Domain.Products.Product>(
                    a => a.Should().BeEquivalentTo(expected,
                        z => z
                        .Excluding(b => b.Id)
                        .Excluding(b => b.CreatedDate)
                        .Excluding(b => b.ModifiedDate)
                        .ComparingByMembers<Domain.Products.Product>())));
        }
    }
}
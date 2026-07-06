using FluentAssertions;
using NetArchTest.Rules;
using ProductManagement.Interface.ReadModel;

namespace ProductManagement.Architecture.Tests.Unit
{
    public class ReadModelAssemblyTests
    {
        private readonly string because = "ReadModel should not depend on ";

        [Fact]
        public void ReadModel_Services_ShouldNot_DependOn_WriteModel()
        {
            var result = GetReadModelAssembly()
                .ShouldNot()
                .HaveDependencyOn("ProductManagement.Interface.WriteModel")
                .GetResult();

            result.IsSuccessful.Should().Be(true, $"{because} WriteModel.");
        }

        [Fact]
        public void ReadModel_Services_ShouldNot_DependOn_Application()
        {
            var result = GetReadModelAssembly()
                .ShouldNot()
                .HaveDependencyOn("ProductManagement.Application")
                .GetResult();

            result.IsSuccessful.Should().Be(true, $"{because} Application.");
        }

        [Fact]
        public void ReadModel_Services_ShouldNot_DependOn_Persistance()
        {
            var result = GetReadModelAssembly()
                .ShouldNot()
                .HaveDependencyOn("ProductManagement.Persistance")
                .GetResult();

            result.IsSuccessful.Should().Be(true, $"{because} Persistance.");
        }

        private PredicateList GetReadModelAssembly()
        {
            return Types
                .InAssembly(typeof(ProductFacadeQuery).Assembly)
                .That()
                .ResideInNamespace("ProductManagement.Interface.ReadModel");
        }
    }
}

using MMTShop.Server.Features.Product.GetProductsByCategory;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.UnitTests
{
    public class GetProductsByCategoryRequestValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            categoryProviderMock = new Mock<ICategoryProvider>();
            sut = new GetProductsByCategoryRequestValidator(categoryProviderMock.Object);
        }

        [Test]
        public void Validate_should_fail_when_category_can_not_be_found()
        {
            var data = new [] { 
                new Category { Name = "Garden" },
                new Category { Name = "Fitness" },
                new Category { Name = "Garden" }
            };

            categoryProviderMock.Setup(a => a.GetCategories(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<IEnumerable<Category>>(data));
            var validationResult = sut.Validate(new GetProductsByCategoryRequest { Category = "Home" });

            Assert.False(validationResult.IsValid);
        }

        [Test]
        public void Validate_should_fail_when_requested_category_is_null()
        {
            var data = new [] { 
                new Category { Name = "Garden" },
                new Category { Name = "Fitness" },
                new Category { Name = "Garden" }
            };

            categoryProviderMock.Setup(a => a.GetCategories(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<IEnumerable<Category>>(data));
            var validationResult = sut.Validate(new GetProductsByCategoryRequest());

            Assert.False(validationResult.IsValid);
        }

        [Test]
        public void Validate_should_pass_when_category_exists()
        {
            var data = new [] { 
                new Category { Name = "Garden" },
                new Category { Name = "Fitness" },
                new Category { Name = "Garden" },
                new Category { Name = "Home" }
            };

            categoryProviderMock.Setup(a => a.GetCategories(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<IEnumerable<Category>>(data));
            var validationResult = sut.Validate(new GetProductsByCategoryRequest { Category = "Garden" });

            Assert.True(validationResult.IsValid);
        }

        private GetProductsByCategoryRequestValidator sut;
        private Mock<ICategoryProvider> categoryProviderMock;
    }
}
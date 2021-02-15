using MMTShop.Server.Features.Product.GetProductsByCategory;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Contracts.Services;
using MMTShop.Shared.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.UnitTests.Validation
{
    public class GetProductsByCategoryRequestValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            categoryProviderMock = new Mock<ICategoryProvider>();
            categoryServiceMock =  new Mock<ICategoryService>();
            sut = new GetProductsByCategoryRequestValidator(
                categoryProviderMock.Object, 
                categoryServiceMock.Object);
        }

        [Test]
        public void Validate_should_fail_when_category_can_not_be_found()
        {
            //arrange
            var data = new [] { 
                new Category { Name = "Garden" },
                new Category { Name = "Fitness" },
                new Category { Name = "Garden" }
            };

            //act
            categoryProviderMock
                .Setup(a => a.GetCategoriesAsync(It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult<IEnumerable<Category>>(data));

            var validationResult = sut
                .Validate(
                    new GetProductsByCategoryRequest { Category = "Home" });

            //assert
            Assert.False(validationResult.IsValid);
        }

        [Test]
        public void Validate_should_call_ICategoryProvider_GetCategories_and_fail_when_requested_category_is_null()
        {
            //arrange
            var data = new [] { 
                new Category { Name = "Garden" },
                new Category { Name = "Fitness" },
                new Category { Name = "Garden" }
            };

            categoryProviderMock.
                Setup(a => a.GetCategoriesAsync(It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult<IEnumerable<Category>>(data))
                    .Verifiable();

            //act
            var validationResult = sut
                .Validate(
                    new GetProductsByCategoryRequest());

            //assert
            categoryProviderMock.Verify();
            Assert.False(validationResult.IsValid);
        }

        [Test]
        public void Validate_should_pass_when_category_exists()
        {
            //arrange
            var data = new [] { 
                new Category { Name = "Garden" },
                new Category { Name = "Fitness" },
                new Category { Name = "Garden" },
                new Category { Name = "Home" }
            };

            categoryProviderMock
                .Setup(a => a.GetCategoriesAsync(It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult<IEnumerable<Category>>(data));
            categoryServiceMock
                .Setup(a => a.GetCategory(It.IsAny<IEnumerable<Category>>(), "Garden"))
                .Returns(new Category { Name = "Garden" });
            //act
            var validationResult = sut
                .Validate(
                    new GetProductsByCategoryRequest { Category = "Garden" });

            //assert
            Assert.True(
                validationResult.IsValid);
        }

        private GetProductsByCategoryRequestValidator sut;
        private Mock<ICategoryProvider> categoryProviderMock;
        private Mock<ICategoryService> categoryServiceMock;
    }
}
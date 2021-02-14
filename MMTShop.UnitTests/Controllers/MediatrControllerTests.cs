using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMTShop.Server.Base;
using MMTShop.UnitTests.Assets;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.UnitTests.Controllers
{
    public class MediatrControllerTests
    {
        [SetUp]
        public void SetUp()
        {
            mediatorMock = new Mock<IMediator>();

            sut = new MediatrControllerBase(
                mediatorMock.Object);
            
        }

        [Test]
        public async Task SendAsync_returns_BadRequest_when_ModelState_is_invalid()
        {
            //arrange
            sut.ModelState
                .AddModelError("Bad request", "long");

            //act
            var result = await sut
                .SendAsync(
                    new object(), 
                    CancellationToken.None);

            //assert
            Assert.True(
                result is BadRequestObjectResult);
        }

        [Test]
        public async Task SendAsync_calls_IMediator_Send_and_returns_BadRequest_when_ResponseBase_has_errors()
        {
            //arrange
            var errorList = new [] { new ValidationFailure(
                    "Bad data", 
                    "Invalid server response"        
            )};

            var request = new object();

            mediatorMock
                .Setup(
                    a => a.Send(
                            request, 
                            CancellationToken.None))
                .Returns(Task
                    .FromResult<object>(
                        new TestResponse { Errors = errorList  }))
                .Verifiable();

            //act
            var result = await sut
                .SendAsync(request, CancellationToken.None);

            //assert

            mediatorMock.Verify();
            Assert.True(
                result is BadRequestObjectResult);
        }

        private Mock<IMediator> mediatorMock;
        private MediatrControllerBase sut;
    }
}

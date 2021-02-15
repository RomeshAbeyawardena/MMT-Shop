using MMTShop.Client;
using MMTShop.Client.Features.Category;
using MMTShop.Client.Features.Product;
using MMTShop.Client.Features.Quit;
using MMTShop.Shared.Contracts;
using MMTShop.Shared.Exceptions;
using Moq;
using NUnit.Framework;
using System;

namespace MMTShop.UnitTests
{
    public class CommandDispatcherManagerTests
    {
        [SetUp]
        public void SetUp()
        {
            dispatcherMock = new Mock<IDispatcherHandler<bool>>();
            serviceProviderMock = new Mock<IServiceProvider>();

            var state = new object();
            serviceProviderMock
                .Setup(a => a
                    .GetService(typeof(ProductDispatcherHandler)))
                .Returns(dispatcherMock.Object)
                .Verifiable();

            serviceProviderMock
                .Setup(a => a
                    .GetService(typeof(CategoryDispatcherHandler)))
                .Returns(dispatcherMock.Object)
                .Verifiable();

            serviceProviderMock
                .Setup(a => a
                    .GetService(typeof(QuitDispatcherHandler)))
                .Returns(dispatcherMock.Object)
                .Verifiable();

            sut = new MenuCommandDispatcher(serviceProviderMock.Object);
        }

        [Test]
        public void DispatcherManager_calls_IServiceProvider_GetService_when_valid_command_is_specified()
        {
            //act
            var dispatcher = sut
                .GetDispatcherHandler<bool>('1');

            //assert
            Assert.AreSame(
                dispatcher,
                dispatcherMock.Object);

            serviceProviderMock
                .Verify(a => a
                    .GetService(
                        typeof(ProductDispatcherHandler)));

            //act
            dispatcher = sut
                .GetDispatcherHandler<bool>('2');

            //assert
            Assert.AreSame(
                dispatcher,
                dispatcherMock.Object);

            serviceProviderMock
                .Verify(a => a
                    .GetService(
                        typeof(CategoryDispatcherHandler)));

            //act
            dispatcher = sut
                .GetDispatcherHandler<bool>('q');

            //assert
            Assert.AreSame(
                dispatcher,
                dispatcherMock.Object);

            serviceProviderMock
                .Verify(a => a
                    .GetService(
                        typeof(QuitDispatcherHandler)));

        }

        [Test]
        public void DispatcherManager_throws_NullReferenceException_when_command_is_invalid()
        {
            Assert
                .Throws<DispatcherNotFoundException>(
                    () =>  {
                            sut.GetDispatcherHandler<bool>('m');
                    });
        }

        private Mock<IDispatcherHandler<bool>> dispatcherMock;
        private Mock<IServiceProvider> serviceProviderMock;
        private MenuCommandDispatcher sut;
    }
}

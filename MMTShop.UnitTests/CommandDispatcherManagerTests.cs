using MMTShop.Client;
using MMTShop.Client.Features.Category;
using MMTShop.Client.Features.Product;
using MMTShop.Client.Features.Quit;
using MMTShop.Shared.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.UnitTests
{
    public class CommandDispatcherManagerTests
    {
        [SetUp]
        public void SetUp()
        {
            dispatcherMock = new Mock<IDispatcher<bool>>();
            serviceProviderMock = new Mock<IServiceProvider>();

            var state = new object();
            serviceProviderMock
                .Setup(a => a
                    .GetService(typeof(ProductDispatcher)))
                .Returns(dispatcherMock.Object)
                .Verifiable();

            serviceProviderMock
                .Setup(a => a
                    .GetService(typeof(CategoryDispatcher)))
                .Returns(dispatcherMock.Object)
                .Verifiable();

            serviceProviderMock
                .Setup(a => a
                    .GetService(typeof(QuitDispatcher)))
                .Returns(dispatcherMock.Object)
                .Verifiable();

            sut = new MenuCommandDispatcherManager(serviceProviderMock.Object);
        }

        [Test]
        public void DispatcherManager_calls_IServiceProvider_GetService_when_valid_command_is_specified()
        {
            //act
            var dispatcher = sut
                .GetDispatcher<bool>('1');

            //assert
            Assert.AreSame(
                dispatcher,
                dispatcherMock.Object);

            serviceProviderMock
                .Verify(a => a
                    .GetService(
                        typeof(ProductDispatcher)));

            //act
            dispatcher = sut
                .GetDispatcher<bool>('2');

            //assert
            Assert.AreSame(
                dispatcher,
                dispatcherMock.Object);

            serviceProviderMock
                .Verify(a => a
                    .GetService(
                        typeof(CategoryDispatcher)));

            //act
            dispatcher = sut
                .GetDispatcher<bool>('q');

            //assert
            Assert.AreSame(
                dispatcher,
                dispatcherMock.Object);

            serviceProviderMock
                .Verify(a => a
                    .GetService(
                        typeof(QuitDispatcher)));

        }

        [Test]
        public void DispatcherManager_throws_NullReferenceException_when_command_is_invalid()
        {
            Assert
                .Throws<NullReferenceException>(
                    () =>  {
                            sut.GetDispatcher<bool>('m');
                    });
        }

        private Mock<IDispatcher<bool>> dispatcherMock;
        private Mock<IServiceProvider> serviceProviderMock;
        private MenuCommandDispatcherManager sut;
    }
}

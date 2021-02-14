using MMTShop.Shared.Base;
using MMTShop.Shared.Contracts.Modules;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Product
{
    public class ProductDispatcher 
        : DispatcherBase<bool>
    {
        public override bool Invoke(
            object state)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> InvokeAsync(
            object state, 
            CancellationToken cancellationToken)
        {
            return productModule
                    .DisplayFeaturedProducts();
        }

        public ProductDispatcher(
            IProductModule productModule)
        {
            this.productModule = productModule;
        }

        private readonly IProductModule productModule;
    }
}

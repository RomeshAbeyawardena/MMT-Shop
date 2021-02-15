using MMTShop.Shared.Base;
using MMTShop.Shared.Contracts.Modules;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Product
{
    public class ProductDispatcherHandler 
        : DispatcherHandlerBase<bool>
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
                    .DisplayFeaturedProductsAsync(cancellationToken);
        }

        public ProductDispatcherHandler(
            IProductModule productModule)
        {
            this.productModule = productModule;
        }

        private readonly IProductModule productModule;
    }
}

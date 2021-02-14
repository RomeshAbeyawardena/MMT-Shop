using MMTShop.Shared.Base;
using MMTShop.Shared.Contracts.Modules;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Category
{
    public class CategoryDispatcher 
        : DispatcherBase<bool>
    {
        public override bool Invoke(object state)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> InvokeAsync(
            object state, 
            CancellationToken cancellationToken)
        {
            return categoryModule
                    .DisplayCategories(productModule
                        .DisplayProductsByCategory);
        }

        public CategoryDispatcher(
            IProductModule productModule,
            ICategoryModule categoryModule)
        {
            this.productModule = productModule;
            this.categoryModule = categoryModule;
        }

        private readonly IProductModule productModule;
        private readonly ICategoryModule categoryModule;
    }
}

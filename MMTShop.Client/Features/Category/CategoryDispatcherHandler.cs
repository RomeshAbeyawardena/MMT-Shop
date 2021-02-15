﻿using MMTShop.Shared.Base;
using MMTShop.Shared.Contracts.Modules;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Category
{
    public class CategoryDispatcherHandler 
        : DispatcherHandlerBase<bool>
    {
        public override bool Invoke(object state)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> InvokeAsync(
            object state, 
            CancellationToken cancellationToken)
        {
            return await categoryModule
                    .DisplayCategories(
                        async(categoryName) => await productModule
                            .DisplayProductsByCategory(
                                categoryName, 
                                cancellationToken),
                        cancellationToken);
        }

        public CategoryDispatcherHandler(
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

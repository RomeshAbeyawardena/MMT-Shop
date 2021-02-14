using System;
using MMTShop.Client.Features.Category;
using MMTShop.Client.Features.Product;
using MMTShop.Client.Features.Quit;
using MMTShop.Shared.Base;

namespace MMTShop.Client
{
    public class MenuCommandDispatcher
        : CommandDispatcherBase<char>
    {
        public MenuCommandDispatcher(
            IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
            DispatcherDictionary
                .TryAdd('1', typeof(ProductDispatcherHandler));

            DispatcherDictionary
                .TryAdd('2', typeof(CategoryDispatcherHandler));

            DispatcherDictionary
                .TryAdd('q', typeof(QuitDispatcherHandler));
        }
    }
}

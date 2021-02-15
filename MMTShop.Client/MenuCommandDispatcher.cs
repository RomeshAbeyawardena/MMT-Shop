using System;
using MMTShop.Client.Features.Category;
using MMTShop.Client.Features.Product;
using MMTShop.Client.Features.Quit;
using MMTShop.Client.Features.ServerCheck;
using MMTShop.Shared.Base;
using MMTShop.Shared.Constants;

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
                .TryAdd(
                    GeneralConstants.ServerCheckCommandCharacter, 
                    typeof(ServerCheckDispatcherHandler));

            DispatcherDictionary
                .TryAdd('1', 
                    typeof(ProductDispatcherHandler));

            DispatcherDictionary
                .TryAdd('2', 
                    typeof(CategoryDispatcherHandler));

            DispatcherDictionary
                .TryAdd('q', 
                    typeof(QuitDispatcherHandler));
        }
    }
}

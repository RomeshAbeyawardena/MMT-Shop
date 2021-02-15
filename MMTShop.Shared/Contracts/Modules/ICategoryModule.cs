using System;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface ICategoryModule
    {
        Task<string> DisplayCategoriesAsync(
            CancellationToken cancellationToken);
    }
}

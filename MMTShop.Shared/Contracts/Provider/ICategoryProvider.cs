using MMTShop.Shared.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Provider
{
    public interface ICategoryProvider
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(
            CancellationToken cancellationToken);
    }
}

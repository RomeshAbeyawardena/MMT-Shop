using MMTShop.Shared.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface ICategoryModule
    {
        Task<IEnumerable<Category>> GetAndDisplayCategoriesAsync(
            CancellationToken cancellationToken);

        string GetSelectedCategory(
            IEnumerable<Category> categories);
    }
}

using System;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface ICategoryModule
    {
        Task<bool> GetCategories(Func<string, Task<bool>> getProductsByCategory);
    }
}

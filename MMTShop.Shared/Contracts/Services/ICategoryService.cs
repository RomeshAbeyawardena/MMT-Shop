using MMTShop.Shared.Models;
using System.Collections.Generic;

namespace MMTShop.Shared.Contracts.Services
{
    public interface ICategoryService
    {
        Category GetCategory(IEnumerable<Category> categories, string category);
    }
}

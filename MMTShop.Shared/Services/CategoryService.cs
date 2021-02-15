using MMTShop.Shared.Contracts.Services;
using MMTShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTShop.Shared.Services
{
    public class CategoryService : ICategoryService
    {
        public Category GetCategory(IEnumerable<Category> categories, string categoryName)
        {
            return categories
                    .FirstOrDefault(category => category.Name.Equals(categoryName,
                        StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

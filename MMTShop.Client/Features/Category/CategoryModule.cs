﻿using MMTShop.Client.Base;
using MMTShop.Shared.Contracts.Modules;
using MMTShop.Shared.Contracts.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Client.Features.Category
{
    public class CategoryModule : ModuleBase, ICategoryModule
    {
        public async Task<bool> GetCategories(Func<string, Task<bool>> getProductsByCategory)
        {
            var categories = await categoryProvider
                .GetCategories(CancellationToken.None);

            DisplayCategories(categories);
            Console.WriteLine("Enter the category you wish to view products for:");

            var categoryName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                if (categories
                    .Any(category => category.Name.Equals(categoryName,
                        StringComparison.InvariantCultureIgnoreCase)))
                {
                    await getProductsByCategory(categoryName);
                    return true;
                }

                Console.WriteLine("Invalid category selected");
            }

            Console.WriteLine("No category selected");

            return true;
        }

        public static void DisplayCategories(
            IEnumerable<Shared.Models.Category> categories)
        {
            Display(categories, "Category", product =>
                string.Format("\tName: {0}{1}",
                    product.Name,
                    newLine));
        }

        public CategoryModule(
            ICategoryProvider categoryProvider)
        {
            this.categoryProvider = categoryProvider;
        }

        private readonly ICategoryProvider categoryProvider;
    }
}

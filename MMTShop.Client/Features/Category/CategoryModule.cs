using MMTShop.Client.Base;
using MMTShop.Shared.Constants;
using MMTShop.Shared.Contracts.Modules;
using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models = MMTShop.Shared.Models;
namespace MMTShop.Client.Features.Category
{
    public class CategoryModule 
        : ModuleBase, ICategoryModule
    {
        public async Task<bool> DisplayCategoriesAsync(
            Func<string, Task<bool>> getProductsByCategory,
            CancellationToken cancellationToken)
        {
            var categories = await categoryProvider
                .GetCategoriesAsync(CancellationToken.None);

            DisplayCategories(categories);
            Console.WriteLine("Enter the category you wish to view products for:");

            var categoryName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                var category = categoryService
                    .GetCategory(
                        categories, 
                        categoryName);

                if (category != null)
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
            IEnumerable<Models.Category> categories)
        {
            Display(categories, "Category", product =>
                string.Format("\tName: {0}{1}",
                    product.Name,
                    FormatConstants.NewLine));
        }

        public CategoryModule(
            ICategoryProvider categoryProvider, ICategoryService categoryService)
        {
            this.categoryProvider = categoryProvider;
            this.categoryService = categoryService;
        }

        private readonly ICategoryProvider categoryProvider;
        private readonly ICategoryService categoryService;
    }
}

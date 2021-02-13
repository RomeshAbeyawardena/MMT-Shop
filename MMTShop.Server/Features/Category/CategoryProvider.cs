using MMTShop.Shared.Contracts.Provider;
using MMTShop.Shared.Contracts.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Features.Category
{
    public class CategoryProvider : ICategoryProvider
    {
        public async Task<IEnumerable<Shared.Models.Category>> GetCategories(
            CancellationToken cancellationToken)
        {
            return await categoryRepository
                .GetCategoriesAsync(cancellationToken);

        }

        public CategoryProvider( 
            ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        private readonly ICategoryRepository categoryRepository;
    }
}

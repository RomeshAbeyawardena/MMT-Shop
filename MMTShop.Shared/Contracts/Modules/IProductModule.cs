using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface IProductModule
    {
        Task<bool> GetFeaturedProducts();
        Task<bool> GetProductsByCategory(
            string categoryName);
    }
}

using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface IProductModule
    {
        Task<bool> DisplayFeaturedProducts();
        Task<bool> DisplayProductsByCategory(
            string categoryName);
    }
}

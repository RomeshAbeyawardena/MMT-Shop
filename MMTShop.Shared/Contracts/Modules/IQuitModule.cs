using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface IQuitModule
    {
        Task<bool> QuitAsync(ApplicationState applicationState);
    }
}

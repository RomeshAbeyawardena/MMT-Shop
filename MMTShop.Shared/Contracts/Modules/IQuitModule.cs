using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Modules
{
    public interface IQuitModule
    {
        Task<bool> QuitAsync(ApplicationState applicationState);
    }
}

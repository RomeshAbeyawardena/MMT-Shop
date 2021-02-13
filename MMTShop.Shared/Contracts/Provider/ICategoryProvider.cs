using MMTShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts.Provider
{
    public interface ICategoryProvider
    {
        Task<IEnumerable<Category>> GetCategories(CancellationToken cancellationToken);
    }
}

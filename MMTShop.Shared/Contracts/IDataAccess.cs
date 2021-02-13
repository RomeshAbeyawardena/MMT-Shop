using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Shared.Contracts
{
    public interface IDataAccess
    {
        CommandDefinition GetCommand(string key, object parameters = null);
    }
}

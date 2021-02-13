using MediatR;
using MMTShop.Shared.Contracts;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShop.Server.Base
{
    public abstract class DbRequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public abstract Task<TResponse> Handle(
            TRequest request, 
            CancellationToken cancellationToken);
   
        protected DbRequestHandlerBase(
            IDbConnection dbConnection,
            IDatabaseQueryProvider dataAccess)
        {
            DbConnection = dbConnection;
            DataAccess = dataAccess;
        }

        protected IDbConnection DbConnection { get; }
        protected IDatabaseQueryProvider DataAccess { get; }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace BE_072024.NetCoreAPI.Dapper
{
    public abstract class BaseApplicationService
    {
        protected IApplicationDbConnection DbConnection { get; }

        public BaseApplicationService(IServiceProvider serviceProvider)
        {
            DbConnection = serviceProvider.GetRequiredService<IApplicationDbConnection>(); ;
        }

    }
}

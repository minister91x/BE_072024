using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_072024.NetCoreAPI.Dapper
{
    public class ApplicationDbConnection : IApplicationDbConnection, IDisposable
    {
        private readonly IDbConnection connection;

        public ApplicationDbConnection(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("ConnStr_BE072024"));
        }

        public IDbConnection GetConnection => this.connection;    


        public void Dispose()
        {
           //this.Dispose();
        }
        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.ExecuteAsync(sql, param, transaction, commandTimeout: 600, commandType: commandType);
        }

        public async Task<List<T>> QueryAsync<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction, commandTimeout: 600, commandType: commandType))?.AsList();

        }

        public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> QuerySingleAsync<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

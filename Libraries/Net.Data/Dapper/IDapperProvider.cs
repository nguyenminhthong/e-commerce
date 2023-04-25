using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Data.Dapper
{
    public interface IDapperProvider
    {
        public Task<int> ExecuteAsync(string sql, DynamicParameters ? parameters, QueryType cmdType = QueryType.PROCEDURE);

        public Task<T> QueryAsync<T>(string sql, DynamicParameters? parameters, QueryType cmdType = QueryType.PROCEDURE);

        public Task<T> SingleResultAsync<T>(string sql, DynamicParameters parameters, QueryType cmdType = QueryType.PROCEDURE);
    }
}

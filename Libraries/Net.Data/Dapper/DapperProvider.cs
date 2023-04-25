using Dapper;
using System.Data;

namespace Net.Data.Dapper
{
    internal class DapperProvider : IDapperProvider
    {
        #region Field
        private readonly IDbConnection _connection;

        #endregion

        #region Ctor
        public DapperProvider(IDbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, DynamicParameters? parameters, QueryType cmdType = QueryType.PROCEDURE)
        {
            return await _connection.ExecuteAsync(sql, parameters, commandType: GetCommandType(cmdType));
        }

        public Task<T> QueryAsync<T>(string sql, DynamicParameters? parameters, QueryType cmdType = QueryType.PROCEDURE)
        {
            throw new NotImplementedException();
        }

        public Task<T> SingleResultAsync<T>(string sql, DynamicParameters parameters, QueryType cmdType = QueryType.PROCEDURE)
        {
            throw new NotImplementedException();
        }

        #region Method

        /// <summary>
        /// Get Command type from Query type param
        /// </summary>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        private CommandType GetCommandType(QueryType cmdType)
        {
            switch (cmdType)
            {
                case QueryType.PROCEDURE: return CommandType.StoredProcedure;
                case QueryType.NATIVE: return CommandType.Text;
                default: return CommandType.Text;
            }
        }

        #endregion
    }
}

namespace MatrimonyAPI.Repository
{
    // DbContext.cs
    using Microsoft.Data.SqlClient;

    using System.Data;
    using System.Threading.Tasks;

    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlCommand CreateCommand()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            return connection.CreateCommand();
        }

        public async Task<int> ExecuteNonQueryAsync(SqlCommand command)
        {
            using (var connection = command.Connection)
            {
                command.Connection = connection;
                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<object> ExecuteScalarAsync(SqlCommand command)
        {
            using (var connection = command.Connection)
            {
                command.Connection = connection;
                return await command.ExecuteScalarAsync();
            }
        }

        public async Task<SqlDataReader> ExecuteReaderAsync(SqlCommand command)
        {
            var connection = command.Connection;
            command.Connection = connection;
            return await command.ExecuteReaderAsync();
        }
    }


}

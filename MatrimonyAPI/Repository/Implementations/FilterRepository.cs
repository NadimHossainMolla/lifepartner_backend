using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.Data.SqlClient;

using System.Data;

namespace MatrimonyAPI.Repository.Implementations
{
    public class FilterRepository : IFilterRepository
    {
        private readonly DbContext _dbContext;

        public FilterRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Filters>> GetAllAsync(FilterRequest request, string storedProcedure)
        {

            var filterList = new List<Filters>();

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@SearchKey", request.SearchText));

                    using (var reader = await _dbContext.ExecuteReaderAsync(command))
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                var filters = new Filters
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    SearchKey = reader.IsDBNull(reader.GetOrdinal("SearchKey")) ? null : reader.GetString(reader.GetOrdinal("SearchKey")),
                                    FilterName = reader.IsDBNull(reader.GetOrdinal("FilterName")) ? null : reader.GetString(reader.GetOrdinal("FilterName")),
                                    FilterValue = reader.IsDBNull(reader.GetOrdinal("FilterValue")) ? null : reader.GetString(reader.GetOrdinal("FilterValue"))


                                };

                                filterList.Add(filters);
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }

            return filterList;
        }
    }
}

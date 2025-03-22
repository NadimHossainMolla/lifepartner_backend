namespace MatrimonyAPI.Repository.Implementations
{
    using MatrimonyAPI.Repository.Interfaces;
    // BaseRepository.cs
    using Microsoft.Data.SqlClient;

    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters for the entity...
                // Example:
                // command.Parameters.Add(new SqlParameter("@Name", entity.Name));

                // Execute the stored procedure and return the result
                var result = await _dbContext.ExecuteScalarAsync(command);
                // Assuming your stored procedure returns an object that can be cast to T
                return (T)result;
            }
        }

        public async Task<T> GetByIdAsync(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));

                var result = await _dbContext.ExecuteScalarAsync(command);
                return (T)result;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            var resultList = new List<T>();
            using (var command = _dbContext.CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = await _dbContext.ExecuteReaderAsync(command))
                {
                    while (await reader.ReadAsync())
                    {
                        // Map the reader to your entity T here
                        var entity = MapReaderToEntity(reader);
                        resultList.Add(entity);
                    }
                }
            }

            return resultList;
        }

        public async Task<T> UpdateAsync(T entity, string storedProcedure)
        {
            // Similar logic as Create, but for Update
            return entity;
        }

        public async Task<bool> DeleteAsync(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));

                var result = await _dbContext.ExecuteNonQueryAsync(command);
                return result > 0;
            }
        }

        private T MapReaderToEntity(SqlDataReader reader)
        {
            // Logic to map SQL data to your entity object
            // Example: 
            // return new T { Name = reader["Name"].ToString(), ... };
            return null;
        }
    }



}

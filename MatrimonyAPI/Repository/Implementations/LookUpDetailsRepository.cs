using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.Data.SqlClient;

using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace MatrimonyAPI.Repository.Implementations
{
    public class LookUpDetailsRepository : ILookUpDetailsRepository
    {
        private readonly DbContext _dbContext;

        public LookUpDetailsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LookUpDetails> CreateAsync(LookUpDetails entity, string storedProcedure)
        {

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@LookUpMasterId", entity.LookUpMasterId);
                    command.Parameters.AddWithValue("@ParentId", entity.ParentId);
                    command.Parameters.AddWithValue("@Name", entity.Name);
                    command.Parameters.AddWithValue("@DisplayName", entity.DisplayName);
                    command.Parameters.AddWithValue("@CreatedOn", entity.CreatedOn);
                    command.Parameters.AddWithValue("@IsActive", entity.IsActive);

                    // Execute the stored procedure and return the result
                    var result = await _dbContext.ExecuteScalarAsync(command);
                    entity.Id = Convert.ToInt32(result);
                    return entity;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }

        }

        public async Task<LookUpDetails> GetByIdAsync(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    var result = await _dbContext.ExecuteReaderAsync(command);
                    LookUpDetails lookUpDetailsModel = null;

                    if (result != null)
                    {
                        try
                        {
                            while (await result.ReadAsync())
                            {
                                lookUpDetailsModel = new LookUpDetails
                                {
                                    Id = result.IsDBNull(result.GetOrdinal("Id")) ? 0 : result.GetInt32(result.GetOrdinal("Id")),
                                    LookUpMasterId = result.IsDBNull(result.GetOrdinal("LookUpMasterId")) ? 0 : result.GetInt32(result.GetOrdinal("LookUpMasterId")),
                                    ParentId = result.IsDBNull(result.GetOrdinal("ParentId")) ? null : result.GetInt32(result.GetOrdinal("ParentId")), // Assuming nullable
                                    Name = result.IsDBNull(result.GetOrdinal("Name")) ? string.Empty : result.GetString(result.GetOrdinal("Name")),
                                    DisplayName = result.IsDBNull(result.GetOrdinal("DisplayName")) ? string.Empty : result.GetString(result.GetOrdinal("DisplayName")),
                                    CreatedOn = result.IsDBNull(result.GetOrdinal("CreatedOn")) ? null : result.GetDateTime(result.GetOrdinal("CreatedOn")), // Assuming nullable
                                    UpdatedOn = result.IsDBNull(result.GetOrdinal("UpdatedOn")) ? null : result.GetDateTime(result.GetOrdinal("UpdatedOn")), // Assuming nullable
                                    IsActive = !result.IsDBNull(result.GetOrdinal("IsActive")) && result.GetBoolean(result.GetOrdinal("IsActive")) // Default false if null
                                };
                            }
                        }
                        finally
                        {
                            result.Close();
                        }
                    }
                    return lookUpDetailsModel;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }
        public async Task<IEnumerable<LookUpDetails>> GetAllAsync(string storedProcedure)
        {
            var lookUpDetailsList = new List<LookUpDetails>();

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await _dbContext.ExecuteReaderAsync(command))
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                var lookUpDetails = new LookUpDetails
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    LookUpMasterId = reader.IsDBNull(reader.GetOrdinal("LookUpMasterId")) ? 0 : reader.GetInt32(reader.GetOrdinal("LookUpMasterId")),
                                    ParentId = reader.IsDBNull(reader.GetOrdinal("ParentId")) ? null : reader.GetInt32(reader.GetOrdinal("ParentId")), // Assuming nullable
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                                    DisplayName = reader.IsDBNull(reader.GetOrdinal("DisplayName")) ? string.Empty : reader.GetString(reader.GetOrdinal("DisplayName")),
                                    CreatedOn = reader.IsDBNull(reader.GetOrdinal("CreatedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("CreatedOn")), // Assuming nullable
                                    UpdatedOn = reader.IsDBNull(reader.GetOrdinal("UpdatedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("UpdatedOn")), // Assuming nullable
                                    IsActive = !reader.IsDBNull(reader.GetOrdinal("IsActive")) && reader.GetBoolean(reader.GetOrdinal("IsActive")) // Default false if null
                                };


                                lookUpDetailsList.Add(lookUpDetails);
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

            return lookUpDetailsList;
        }

        public async Task<LookUpDetails> UpdateAsync(LookUpDetails entity, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {

                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters for updating the entity
                    command.Parameters.AddWithValue("@LookUpMasterId", entity.LookUpMasterId);
                    command.Parameters.AddWithValue("@ParentId", entity.ParentId);
                    command.Parameters.AddWithValue("@Name", entity.Name);
                    command.Parameters.AddWithValue("@DisplayName", entity.DisplayName);
                    command.Parameters.AddWithValue("@UpdatedOn", entity.UpdatedOn);
                    command.Parameters.AddWithValue("@IsActive", entity.IsActive);

                    // Execute the stored procedure (if you expect a value returned)
                    var result = await _dbContext.ExecuteScalarAsync(command);

                    // Optionally, you can map the result back to the entity
                    // You can also add additional logic based on the result if needed

                    return entity; // returning the updated entity
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }


        public async Task<bool> DeleteAsync(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    var result = await _dbContext.ExecuteNonQueryAsync(command);
                    return result > 0;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<IEnumerable<LookUpDetails>> GetByParentIdAsync(int id, string storedProcedure)
        {
            var lookUpDetailsList = new List<LookUpDetails>();

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ParentId", id));

                    var result = await _dbContext.ExecuteReaderAsync(command);
                    LookUpDetails lookUpDetailsModel = null;

                    if (result != null)
                    {
                        try
                        {
                            while (await result.ReadAsync())
                            {
                                lookUpDetailsModel = new LookUpDetails
                                {
                                    Id = result.IsDBNull(result.GetOrdinal("Id")) ? 0 : result.GetInt32(result.GetOrdinal("Id")),
                                    LookUpMasterId = result.IsDBNull(result.GetOrdinal("LookUpMasterId")) ? 0 : result.GetInt32(result.GetOrdinal("LookUpMasterId")),
                                    ParentId = result.IsDBNull(result.GetOrdinal("ParentId")) ? null : result.GetInt32(result.GetOrdinal("ParentId")), // Assuming nullable
                                    Name = result.IsDBNull(result.GetOrdinal("Name")) ? string.Empty : result.GetString(result.GetOrdinal("Name")),
                                    DisplayName = result.IsDBNull(result.GetOrdinal("DisplayName")) ? string.Empty : result.GetString(result.GetOrdinal("DisplayName")),
                                    CreatedOn = result.IsDBNull(result.GetOrdinal("CreatedOn")) ? null : result.GetDateTime(result.GetOrdinal("CreatedOn")), // Assuming nullable
                                    UpdatedOn = result.IsDBNull(result.GetOrdinal("UpdatedOn")) ? null : result.GetDateTime(result.GetOrdinal("UpdatedOn")), // Assuming nullable
                                    IsActive = !result.IsDBNull(result.GetOrdinal("IsActive")) && result.GetBoolean(result.GetOrdinal("IsActive")) // Default false if null
                                };

                                lookUpDetailsList.Add(lookUpDetailsModel);
                            }
                        }
                        finally
                        {
                            result.Close();
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
                return lookUpDetailsList;
            }
        }

        public async Task<IEnumerable<LookUpDetails>> GetByMasterNameAsync(string name, string storedProcedure)
        {
            var lookUpDetailsList = new List<LookUpDetails>();

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MasterName", name));

                    using (var reader = await _dbContext.ExecuteReaderAsync(command))
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                var lookUpDetails = new LookUpDetails
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    LookUpMasterId = reader.IsDBNull(reader.GetOrdinal("LookUpMasterId")) ? 0 : reader.GetInt32(reader.GetOrdinal("LookUpMasterId")),
                                    ParentId = reader.IsDBNull(reader.GetOrdinal("ParentId")) ? null : reader.GetInt32(reader.GetOrdinal("ParentId")), // Assuming nullable
                                    Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                                    DisplayName = reader.IsDBNull(reader.GetOrdinal("DisplayName")) ? string.Empty : reader.GetString(reader.GetOrdinal("DisplayName")),
                                    CreatedOn = reader.IsDBNull(reader.GetOrdinal("CreatedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("CreatedOn")), // Assuming nullable
                                    UpdatedOn = reader.IsDBNull(reader.GetOrdinal("UpdatedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("UpdatedOn")), // Assuming nullable
                                    IsActive = !reader.IsDBNull(reader.GetOrdinal("IsActive")) && reader.GetBoolean(reader.GetOrdinal("IsActive")) // Default false if null
                                };


                                lookUpDetailsList.Add(lookUpDetails);
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

            return lookUpDetailsList;
        }

    }
}

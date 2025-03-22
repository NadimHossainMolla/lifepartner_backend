using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.Data.SqlClient;

using System.Data;
using System.Reflection.PortableExecutable;

namespace MatrimonyAPI.Repository.Implementations
{
    public class FilesRepository : IFilesRepository
    {
        private readonly DbContext _dbContext;
        public FilesRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<FileSaveRequest> SaveAsync(FileSaveRequest file, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@AccountId", file.AccountId);
                    command.Parameters.AddWithValue("@filetype", file.FileType);
                    command.Parameters.AddWithValue("@filename", file.FileName);
                    command.Parameters.AddWithValue("@filepath", file.FilePath);
                    command.Parameters.AddWithValue("@UploadedOn", file.UploadedOn);

                    // Execute the stored procedure and return the result
                    var result = await _dbContext.ExecuteScalarAsync(command);
                    file.Id = Convert.ToInt32(result);
                    return file;
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

        public async Task<Files> GetByIdAsync(int Id, string storedProcedure)
        {
            Files FileItem = new Files();
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@Id", Id);

                    // Execute the stored procedure and return the result
                    var reader = await _dbContext.ExecuteReaderAsync(command);
                    while (await reader.ReadAsync())
                    {
                        FileItem.Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id"));
                        FileItem.FileName = reader.IsDBNull(reader.GetOrdinal("FileName")) ? null : reader.GetString(reader.GetOrdinal("FileName"));
                        FileItem.FileType = reader.IsDBNull(reader.GetOrdinal("FileType")) ? null : reader.GetString(reader.GetOrdinal("FileType"));
                        FileItem.FilePath = reader.IsDBNull(reader.GetOrdinal("FilePath")) ? null : reader.GetString(reader.GetOrdinal("FilePath"));
                        FileItem.AccountId = reader.IsDBNull(reader.GetOrdinal("AccountId")) ? 0 : reader.GetInt32(reader.GetOrdinal("AccountId"));
                        FileItem.UploadedOn = reader.GetDateTime(reader.GetOrdinal("UploadedOn"));
                        FileItem.IsPrimary = reader.IsDBNull(reader.GetOrdinal("IsPrimary")) ? false : reader.GetBoolean(reader.GetOrdinal("IsPrimary"));
                        FileItem.IsVerified = reader.IsDBNull(reader.GetOrdinal("IsVerified")) ? false : reader.GetBoolean(reader.GetOrdinal("IsVerified"));
                        FileItem.VerifiedOn = reader.IsDBNull(reader.GetOrdinal("VerifiedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("VerifiedOn"));

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
            return FileItem;
        }

        public async Task<IEnumerable<Files>> GetAllByTypeAsync(int AccountId, string fileType, string storedProcedure)
        {
            var fileList = new List<Files>();

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@AccountId", AccountId);
                    command.Parameters.AddWithValue("@FileType", fileType);

                    using (var reader = await _dbContext.ExecuteReaderAsync(command))
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                var file = new Files
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    FileName = reader.IsDBNull(reader.GetOrdinal("FileName")) ? null : reader.GetString(reader.GetOrdinal("FileName")),
                                    FileType = reader.IsDBNull(reader.GetOrdinal("FileType")) ? null : reader.GetString(reader.GetOrdinal("FileType")),
                                    FilePath = reader.IsDBNull(reader.GetOrdinal("FilePath")) ? null : reader.GetString(reader.GetOrdinal("FilePath")),
                                    AccountId = reader.IsDBNull(reader.GetOrdinal("AccountId")) ? 0 : reader.GetInt32(reader.GetOrdinal("AccountId")),
                                    UploadedOn = reader.GetDateTime(reader.GetOrdinal("UploadedOn")),
                                    IsPrimary = reader.IsDBNull(reader.GetOrdinal("IsPrimary")) ? false : reader.GetBoolean(reader.GetOrdinal("IsPrimary")),
                                    IsVerified = reader.IsDBNull(reader.GetOrdinal("IsVerified")) ? false : reader.GetBoolean(reader.GetOrdinal("IsVerified")),
                                    VerifiedOn = reader.IsDBNull(reader.GetOrdinal("VerifiedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("VerifiedOn"))
                                };

                                fileList.Add(file);
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

            return fileList;
        }
        public async Task<IEnumerable<Files>> GetAllByAccountAsync(int AccountId, string storedProcedure)
        {
            var fileList = new List<Files>();

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@AccountId", AccountId);

                    using (var reader = await _dbContext.ExecuteReaderAsync(command))
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                var file = new Files
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    FileName = reader.IsDBNull(reader.GetOrdinal("FileName")) ? null : reader.GetString(reader.GetOrdinal("FileName")),
                                    FileType = reader.IsDBNull(reader.GetOrdinal("FileType")) ? null : reader.GetString(reader.GetOrdinal("FileType")),
                                    FilePath = reader.IsDBNull(reader.GetOrdinal("FilePath")) ? null : reader.GetString(reader.GetOrdinal("FilePath")),
                                    AccountId = reader.IsDBNull(reader.GetOrdinal("AccountId")) ? 0 : reader.GetInt32(reader.GetOrdinal("AccountId")),
                                    UploadedOn = reader.GetDateTime(reader.GetOrdinal("UploadedOn")),
                                    IsPrimary = reader.IsDBNull(reader.GetOrdinal("IsPrimary")) ? false : reader.GetBoolean(reader.GetOrdinal("IsPrimary")),
                                    IsVerified = reader.IsDBNull(reader.GetOrdinal("IsVerified")) ? false : reader.GetBoolean(reader.GetOrdinal("IsVerified")),
                                    VerifiedOn = reader.IsDBNull(reader.GetOrdinal("VerifiedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("VerifiedOn"))
                                };

                                fileList.Add(file);
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

            return fileList;
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

        public async Task<bool> SetAsDefaultAsync(int id, int AccountId, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@AccountId", AccountId));

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

    }
}

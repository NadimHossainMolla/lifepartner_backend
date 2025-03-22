using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.DTO.Response;
using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.Data.SqlClient;

using System.Data;

namespace MatrimonyAPI.Repository.Implementations
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly DbContext _dbContext;

        public ProposalRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProposalResponse> Send(ProposalRequest proposal, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add input parameters
                    command.Parameters.AddWithValue("@SendTo", proposal.SendTo);
                    command.Parameters.AddWithValue("@SendBy", proposal.SendBy);

                    // Add output parameter
                    var proposalIdParam = new SqlParameter("@ProposalId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(proposalIdParam);

                    // Execute stored procedure
                    await _dbContext.ExecuteNonQueryAsync(command);

                    // Retrieve output parameter value
                    ProposalResponse response = new ProposalResponse
                    {
                        ProposalId = Convert.ToInt32(proposalIdParam.Value)
                    };

                    return response;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure connection is closed
                    }
                }
            }
        }

    }
}

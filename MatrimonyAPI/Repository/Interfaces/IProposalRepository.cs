using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.DTO.Response;
using MatrimonyAPI.Models;
using MatrimonyAPI.Models.ViewModels;

namespace MatrimonyAPI.Repository.Interfaces
{
    public interface IProposalRepository
    {
        Task<ProposalResponse> Send(ProposalRequest request, string storedProcedure);
    }
}

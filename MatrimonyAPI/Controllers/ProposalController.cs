using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Implementations;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProposalController : Controller
    {
        private readonly IProposalRepository _proposalRepository;

        public ProposalController(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromBody] ProposalRequest request)
        {
            var proposalId = await _proposalRepository.Send(request, "usp_InsertProposal");

            return Ok(proposalId);
        }
    }
}

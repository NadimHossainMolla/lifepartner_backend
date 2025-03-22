using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FilterController : ControllerBase
    {
        private readonly IFilterRepository _FilterRepository;

        public FilterController(IFilterRepository FilterRepository)
        {
            _FilterRepository = FilterRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Filter([FromBody] FilterRequest FilterRequest)
        {
            var foundFilters = await _FilterRepository.GetAllAsync(FilterRequest, "usp_GetAllFilters");

            if (foundFilters != null)
            {
                 return Ok(foundFilters);
               
            }
            else
            {
                return NotFound("Filter does not exists!");
            }
        }
    }
}

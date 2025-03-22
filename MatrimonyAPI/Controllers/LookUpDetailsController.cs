using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LookUpDetailsController : ControllerBase
    {
        private readonly ILookUpDetailsRepository _lookUpDetailsRepository;

        public LookUpDetailsController(ILookUpDetailsRepository lookUpDetailsRepository)
        {
            _lookUpDetailsRepository = lookUpDetailsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LookUpDetails entity)
        {
            var createdEntity = await _lookUpDetailsRepository.CreateAsync(entity, "usp_InsertLookUpDetails");

            return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _lookUpDetailsRepository.GetByIdAsync(id, "usp_GetLookUpDetailsById");

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _lookUpDetailsRepository.GetAllAsync("usp_GetAllLookUpDetails");

            return Ok(entities);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LookUpDetails entity)
        {
            entity.Id = id;
            var updatedentity = await _lookUpDetailsRepository.UpdateAsync(entity, "usp_InsertLookUpDetails");

            return Ok(updatedentity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             bool isDeleted = await _lookUpDetailsRepository.DeleteAsync(id, "usp_DeleteLookUpDetails");

            return isDeleted ? NoContent() : NotFound();
        }

        [HttpGet("ByParentId")]
        public async Task<IActionResult> GetByParentId(int ParentId)
        {
            var account = await _lookUpDetailsRepository.GetByParentIdAsync(ParentId, "usp_GetLookUpDetailsByParentId");

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpGet("ByMasterName")]
        public async Task<IActionResult> GetByMasterName(string name)
        {
            var account = await _lookUpDetailsRepository.GetByMasterNameAsync(name, "usp_GetLookUpDetailsByMasterName");

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}

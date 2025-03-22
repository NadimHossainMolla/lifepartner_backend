using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Implementations;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FilesController : ControllerBase
    {
        private readonly IFilesRepository _filesRepository;

        public FilesController(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] FileUploadRequest fileUploadRequest)
        {
            try
            {
                // Define the directory path dynamically based on the AccountId
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", fileUploadRequest.accountId.ToString());
                
                // Create the directory if it does not exist
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Define the full file path
                var filePath = Path.Combine(directoryPath, fileUploadRequest.file.FileName);
                var fileSavePath = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/UploadedFiles/{fileUploadRequest.accountId}/{fileUploadRequest.file.FileName}";

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUploadRequest.file.CopyToAsync(stream);
                }
                FileSaveRequest fileSaveRequest = new FileSaveRequest();
                fileSaveRequest.AccountId = fileUploadRequest.accountId;
                fileSaveRequest.FilePath = fileSavePath;
                fileSaveRequest.FileType = fileUploadRequest.fileType;
                fileSaveRequest.FileName = fileUploadRequest.file.FileName;
                fileSaveRequest.UploadedOn = DateTime.Now;
                var savedFile = await _filesRepository.SaveAsync(fileSaveRequest, "usp_InsertFile");

                return CreatedAtAction(nameof(GetById), new { id = savedFile.Id }, savedFile);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while uploading the file.", Error = ex.Message });
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Fetch account by ID
            var account = await _filesRepository.GetByIdAsync(id, "usp_GetFileById");

            // Return 404 if account not found, otherwise return account
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpGet("ByAccount")]
        public async Task<IActionResult> GetAllByAccount(int AcccountId)
        {
            // Get all accounts
            var accounts = await _filesRepository.GetAllByAccountAsync(AcccountId,"usp_GetAllFilesByAccount");

            return Ok(accounts);
        }

        [HttpGet("ByFileType")]
        public async Task<IActionResult> GetAllByFileType(int AcccountId, string FileType)
        {
            // Get all accounts
            var accounts = await _filesRepository.GetAllByTypeAsync(AcccountId, FileType, "usp_GetAllFilesByType");

            return Ok(accounts);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Delete account by ID
            bool isDeleted = await _filesRepository.DeleteAsync(id, "usp_DeleteFile");

            return isDeleted ? NoContent() : NotFound();
        }

        [HttpPut("SetAsDefault")]
        public async Task<IActionResult> SetAsDefault(int id,int AccountId)
        {
            // Delete account by ID
            bool isSet = await _filesRepository.SetAsDefaultAsync(id,AccountId, "usp_SetAsDefaultFile");

            return isSet ? NoContent() : NotFound();
        }

    }
}

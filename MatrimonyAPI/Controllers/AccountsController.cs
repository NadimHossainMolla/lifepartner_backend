using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace MatrimonyAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AccountsController : ControllerBase
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountsController(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Accounts account)
        {
            // Call the repository method to create a new account
            var createdAccount = await _accountsRepository.CreateAsync(account, "usp_InsertAccount");

            // Return the created account object with a 201 status code
            return CreatedAtAction(nameof(GetById), new { id = createdAccount.Id }, createdAccount);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Fetch account by ID
            var account = await _accountsRepository.GetByIdAsync(id, "usp_GetAccountById");

            // Return 404 if account not found, otherwise return account
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpGet("DetailsById")]
        public async Task<IActionResult> GetDetailsById(int id, int accountId)
        {
            // Fetch account by ID
            var account = await _accountsRepository.GetDetailsByIdAsync(id,accountId, "usp_GetAccountDetailsById");

            // Return 404 if account not found, otherwise return account
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get all accounts
            var accounts = await _accountsRepository.GetAllAsync("usp_GetAccountDetailsById");

            return Ok(accounts);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Accounts account)
        {
            var updatedAccount = await _accountsRepository.UpdateAsync(account, "usp_InsertAccount");

            return Ok(updatedAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Delete account by ID
            bool isDeleted = await _accountsRepository.DeleteAsync(id, "usp_DeleteAccount");

            return isDeleted ? NoContent() : NotFound();
        }

        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest registrationRequest)
        {
            // Call the repository method to create a new account
            var registeredAccount = await _accountsRepository.RegisterAsync(registrationRequest, "usp_RegisterAccount");

            if (registeredAccount.Id > 0)
                // Return the created account object with a 201 status code
                return CreatedAtAction(nameof(GetById), new { id = registeredAccount.Id }, registeredAccount);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("List")]
        public async Task<IActionResult> GetAllWithFilter([FromBody] AccountListRequest request)
        {
            // Get all accounts
            var accounts = await _accountsRepository.GetAllWithFilterAsync(request,"usp_GetAllAccounts");

            return Ok(accounts);
        }

        [HttpGet("SideBarDetailsById/{id}")]
        public async Task<IActionResult> GetSideBarDetailsById(int id)
        {
            // Fetch account by ID
            var details = await _accountsRepository.GetSideBarDetailsById(id, "usp_GetSideBarDetailsById");

            // Return 404 if account not found, otherwise return account
            if (details == null)
            {
                return NotFound();
            }

            return Ok(details);
        }

        [HttpGet("ProfileDetailsById/{id}")]
        public async Task<IActionResult> GetProfileDetailsById(int id)
        {
            // Fetch account by ID
            var details = await _accountsRepository.GetProfileDetailsById(id, "usp_GetProfileDetailsById");

            // Return 404 if account not found, otherwise return account
            if (details == null)
            {
                return NotFound();
            }

            return Ok(details);
        }

        [HttpGet("DashboardStatsById/{id}")]
        public async Task<IActionResult> GetDashboardStatsById(int id)
        {
            // Fetch account by ID
            var details = await _accountsRepository.GetDashboardStatsById(id, "usp_GetDashboardStatsById");

            // Return 404 if account not found, otherwise return account
            if (details == null)
            {
                return NotFound();
            }

            return Ok(details);
        }

        [HttpPut("PersonalInfo")]
        public async Task<IActionResult> UpdatePersonalInfo([FromBody] PersonalInfo personalInfo)
        {
            personalInfo.UpdatedOn = DateTime.Now;
            var updatedPersonalInfo = await _accountsRepository.UpdatePersonalInfoAsync(personalInfo, "usp_UpdatePersonalInfo");
            return Ok(updatedPersonalInfo);
        }

        [HttpPut("BioDetails")]
        public async Task<IActionResult> UpdateBioDetails([FromBody] BioDetails bioDetails)
        {
            bioDetails.UpdatedOn = DateTime.Now;
            var updatedbioDetails = await _accountsRepository.UpdateBioDetailsAsync(bioDetails, "usp_UpdateBioDetails");
            return Ok(updatedbioDetails);
        }

        [HttpPut("OccupationAndEducationDetails")]
        public async Task<IActionResult> UpdateOccupationAndEducationDetails([FromBody] OccupationAndEducationDetails details)
        {
            details.UpdatedOn = DateTime.Now;
            var updatedDetails = await _accountsRepository.UpdateOccupationAndEducationDetailsAsync(details, "usp_UpdateOccupationAndEducationDetails");
            return Ok(updatedDetails);
        }

        [HttpPut("FamilyDetails")]
        public async Task<IActionResult> UpdateFamilyDetails([FromBody] FamilyDetails details)
        {
            details.UpdatedOn = DateTime.Now;
            var updatedDetails = await _accountsRepository.UpdateFamilyDetailsAsync(details, "usp_UpdateFamilyDetails");
            return Ok(updatedDetails);
        }

        [HttpGet("CheckProfileStepValue")]
        public async Task<IActionResult> CheckProfileStepValueById(int id,string step)
        {
            // Fetch account by ID
            var details = await _accountsRepository.CheckProfileStepValueById(id,step,"usp_CheckProfileStepValue");
            var result = new
            {
                AccountId=id,
                Step=step,
                IsTrue = details
            };
            string jsonString= JsonConvert.SerializeObject(result);

            // Return 404 if account not found, otherwise return account
            if (details == null)
            {
                return NotFound();
            }

            return Ok(jsonString);
        }


    }

}

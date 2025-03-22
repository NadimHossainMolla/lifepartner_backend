using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Text;

namespace MatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginRepository loginRepository,IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var foundAccount = await _loginRepository.LoginAsync(loginRequest, "usp_LoginAccount");

            if (foundAccount != null)
            {
                if (foundAccount.Password != null && foundAccount.Password == loginRequest.Password) {
                    var token = GenerateJwtToken();
                    return Ok(new { id = foundAccount.Id,token=token });
                }  
                else
                    return NotFound("Username or Password is incorrect!");
            }
            else
            {
                return NotFound("User does not exists!");
            }
        }

        private string GenerateJwtToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

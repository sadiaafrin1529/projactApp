using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using projactApp.Module;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace projactApp.Controllers
{
    
    [ApiController]
    public class DemoApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DemoApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("GetTestUnAuthorise")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTestUnAuthorise()
        {
            return Ok("Hello Word From UnAuthorise");
        }

        [Route("GetTestAuthorise")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetTestAuthorise()
        {
            return Ok("Hello Word From GetTestAuthorise");
        }


        [Route("CheckLogin")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CheckLogin(Contact model)
        {
            if (model.LoginID=="admin" && model.Password=="password")
            {
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", model.LoginID)
                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                model.UserMessage = "Login Success";
                model.UserToken = new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                model.UserMessage="login Failed";
            }
            return Ok(model);
        }
    }
}

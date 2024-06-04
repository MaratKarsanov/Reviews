using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Review.Domain.Models;
using Review.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConfigurationManager = Review.Domain.Services.ConfigurationManager;

namespace ReviewsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly LoginService loginService;

        public AuthenticationController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (login is null)
                return BadRequest("Invalid login request!");
            var result = loginService.CheckLogin(login);
            if (result)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"], 
                    audience: ConfigurationManager.AppSetting["JWT:ValidAudience"], 
                    claims: new List<Claim>(), 
                    expires: DateTime.Now.AddMinutes(6), 
                    signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new JWTTokenResponse
                {
                    Token = tokenString
                });
            }
            return Unauthorized();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySmartHome.DAL.Data;
using MySmartHome.DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MySmartHomeWebApi.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserDbContext _context;
        private readonly PasswordHasher<IdentityUser> passwordHasher;

        public LoginController(UserDbContext context)
        {
            _context = context;
            passwordHasher = new();
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(Users credentials)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Email == credentials.Email);
            if (user is null)
                return Unauthorized();
            
            var isHashValid = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, credentials.Password);

            if (isHashValid == PasswordVerificationResult.Failed)
                return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = user.Email
            };
            return Ok(response);
        }


    }
}

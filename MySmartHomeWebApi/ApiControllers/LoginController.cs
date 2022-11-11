using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySmartHomeWebApi.Data;
using MySmartHomeWebApi.Data.Interfaces;
using MySmartHomeWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
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
            return Ok(Results.Json(response));
        }

        //[HttpPost("SignUp")]
        //public async Task<IActionResult> SignIn(Persons user)
        //{
        //    var isExist = await _repository.GetByEmail(user.Email);
        //    if(isExist is not null) 
        //        return Conflict(user.Email);
        //    user.Id = Guid.NewGuid();
        //    user.Role = Roles.Users;
        //    user.Password = passwordHasher.HashPassword(user, user.Password);
        //    return Ok(await _repository.Add(user));
        //}

        //[HttpPost("user")]
        //public async Task<ActionResult> GetByEmail([FromBody] string email)
        //{
        //    var person = await _repository.GetByEmail(email);
        //    return person is null ? NotFound() : Ok(person);
        //}

        //// PUT api/<LoginController>/edit
        //[HttpPut("edit")]
        //public async Task<IActionResult> Put([FromBody] Persons user)
        //{
        //    user.Password = passwordHasher.HashPassword(user, user.Password);
        //    return Ok(await _repository.Update(user));
        //}

        //// DELETE api/<LoginController>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    return Ok(await _repository.DeleteById(id));
        //}

    }
}

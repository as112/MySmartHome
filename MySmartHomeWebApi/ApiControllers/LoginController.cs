using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IUserRepository<Persons> _repository;
        private readonly PasswordHasher<Persons> passwordHasher;

        public LoginController(IUserRepository<Persons> repository)
        {
            _repository = repository;
            passwordHasher = new();
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(Persons credentials)
        {
            var person = await _repository.GetByEmail(credentials.Email);
            
            if (person is null)
                return Unauthorized();

            var hash = passwordHasher.HashPassword(person, credentials.Password);
            var isHashValid = passwordHasher.VerifyHashedPassword(person, hash, person.Password);

            if (isHashValid == PasswordVerificationResult.Failed)
                return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
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
                username = person.Email
            };
            return Ok(Results.Json(response));
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignIn(Persons user)
        {
            var isExist = await _repository.GetByEmail(user.Email);
            if(isExist is not null) 
                return Conflict(user.Email);
            user.Id = Guid.NewGuid();
            user.Role = Roles.Users;
            user.Password = passwordHasher.HashPassword(user, user.Password);
            return Ok(await _repository.Add(user));
        }

        [HttpPost("user")]
        public async Task<ActionResult> GetByEmail([FromBody] string email)
        {
            var person = await _repository.GetByEmail(email);
            return person is null ? NotFound() : Ok(person);
        }

        // PUT api/<LoginController>/edit
        [HttpPut("edit")]
        public async Task<IActionResult> Put([FromBody] Persons user)
        {
            user.Password = passwordHasher.HashPassword(user, user.Password);
            return Ok(await _repository.Update(user));
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _repository.DeleteById(id));
        }

    }
}

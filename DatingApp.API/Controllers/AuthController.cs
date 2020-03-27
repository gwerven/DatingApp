using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Route will be api/auth (after slash will be what is before "Controller" below)
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // Validate the request

            // Don't accept duplicate usernames where only difference being capital letters
            // Convert all input usernames to lowercase (username witll not be case sensitive)
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            // If username already exists, return bad request error
            if(await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");
            
            // Create new user with the input username
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            // Return success message that user was created at route
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            // Get the user's entered login credentials
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if(userFromRepo == null)
                return Unauthorized();

            // Start building token. Token contains 2 claims (Id and Name)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            // Create symmetric key. Server signs the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            // Hashes the security key we generated above
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Set expiration time for token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // Token expire after 1 day (24 hours)
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            // Contains our JWT token to return to user
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Send token to client
            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Route will be api/auth (after slash will be what is before "Controller" below)
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
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
    }
}
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
        // Interface for the repository

        // Register a new user
         Task<User> Register(User user, string password);
         // Login an existing user
         Task<User> Login(string username, string password);
         // Check is a user exists for a given username
         Task<bool> UserExists(string username);
    }
}
using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        // Query database using Entity Framework

        private readonly DataContext _context;
        // Inject DataContext
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            // Get user with matching username. If no matching user, return null (default)
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            // User doesn't exist
            if(user == null)
                return null;
            
            // Password doesn't match
            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                /* Create hash from password using key(salt). Will result in same password hash
                used in CreatePasswordHash() method */
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                // If each byte in array of computed hash does not match password hash, return false (passwords don't match)
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] !=passwordHash[i]) return false;
                }
                // If each byte in array of computed hash matches password hash, return true (passwords match)
                return true;
            }
        }

        // Takes User model/entity and password and creates new user with those credentials
        public async Task<User> Register(User user, string password)
        {
            // Covert password into password hash and password salt
            byte[] passwordHash, passwordSalt;
            // Use out keyword to only pass a reference
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // After generated, set the hash and salt for the user
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Make asynchronous
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // We can use using to dispose of anything after we're done with it
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                // Use randomly generated key as salt
                passwordSalt = hmac.Key;
                // Convert password to a byte array and then hash it
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            // If matching username found in database, return true (user exists)
            if(await _context.Users.AnyAsync(x => x.Username == username))
                return true;
            
            // If no matching username found in database, return false (user doesn't exist)
            return false;
        }
    }
}
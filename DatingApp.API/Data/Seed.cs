using System.Collections.Generic;
using System.Linq;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        // Seed data into db at startup
        public static void SeedUsers(DataContext context)
        {
            if(!context.Users.Any())
            {
                // Read the .json file
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                // Deserialize the objects
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                // Loop through each user
                foreach(var user in users)
                {
                    // Encrypt the passwords before storing in the db
                    byte[] passwordhash, passwordSalt;
                    CreatePasswordHash("password", out passwordhash, out passwordSalt);

                    // Populate user objects
                    user.PasswordHash = passwordhash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();
                    context.Users.Add(user);
                }

                // Save changes after populating user objects
                context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
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
    }
}
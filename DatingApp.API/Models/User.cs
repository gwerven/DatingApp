namespace DatingApp.API.Models
{
    public class User
    {
        // User's id (primary key)
        public int Id { get; set; }

        // Username
        public string Username { get; set; }

        // The hash of the user's password
        public byte[] PasswordHash { get; set; }

        /* The salt of the user's password (acts as a key that we can use to recreate the hash
        and compare it with the generated hash of the password the user types in */
        public byte[] PasswordSalt { get; set; }
    }
}
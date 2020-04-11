using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class User
    {
        // User's id (primary key), automattically set
        public int Id { get; set; }

        // Username
        public string Username { get; set; }

        // The hash of the user's password
        public byte[] PasswordHash { get; set; }

        /* The salt of the user's password (acts as a key that we can use to recreate the hash
        and compare it with the generated hash of the password the user types in */
        public byte[] PasswordSalt { get; set; }

        // The user's gender
        public string gender { get; set; }

        // The user's date of birth
        public DateTime DateOfBirth { get; set; }

        // The user's name to be shown on their account (different from their username)
        public string KnownAs { get; set; }

        // The date the user created their account (how long they've been a user)
        public DateTime Created { get; set; }

        // The date and time the user was last active
        public DateTime LastActive { get; set; }

        // The user profile's biography
        public string Introduction { get; set; }

        // The gender the user is looking for as a partner
        public string LookingFor { get; set; }

        // The user's interests
        public string Interests { get; set; }

        // The city the user is located in
        public string City { get; set; }

        // The country the user is located in
        public string Country { get; set; }

        // A collection of the user's profile photos
        public ICollection<Photo> Photos { get; set; }
    }
}
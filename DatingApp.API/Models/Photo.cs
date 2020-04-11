using System;

namespace DatingApp.API.Models
{
    public class Photo
    {
        // The photo id
        public int Id { get; set; }

        // A string for the URL location of the photo
        public string Url { get; set; }

        // A short description of the photo
        public string Description { get; set; }

        // The date the photo was uploaded
        public DateTime DateAdded { get; set; }

        /* Whether the photo is the user's main profile
        photo (true) or just an additional photo (false) */
        public bool IsMain { get; set; }

        // Used to show Entity Framework the relationship between User.cs and Photo.cs
        // Gives us a cascaded delete instead of a restricted delete
        public User User { get; set; }

        // The id of the user the photo belongs to
        public int UserId { get; set; }
    }
}
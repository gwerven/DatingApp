using System;

namespace DatingApp.API.Dtos
{
    public class PhotosForDetailedDto
    {
        // Dto for photos for detailed page without user connection that EF needs
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
    }
}
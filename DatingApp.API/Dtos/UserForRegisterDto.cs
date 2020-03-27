using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        // Makes the username required to have an input and not be empty
        [Required]
        public string Username { get; set; }
        // Makes the password required to have an input and not be empty
        [Required]
        // Validates that the input password is between 4 and 8 characters in length
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}
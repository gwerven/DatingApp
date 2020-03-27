namespace DatingApp.API.Dtos
{
    public class UserForLoginDto
    {
        // No validation necessary here. Validation done in UserForRegisterDto.cs
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
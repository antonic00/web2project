using web2server.Enums;

namespace web2server.Dtos
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public string Address { get; set; }
        public UserRole Role { get; set; }
        public VerificationStatus? VerificationStatus { get; set; }
    }
}

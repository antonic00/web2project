using web2server.Enums;

namespace web2server.Dtos
{
    public class VerifyDto
    {
        public long UserId { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
    }
}

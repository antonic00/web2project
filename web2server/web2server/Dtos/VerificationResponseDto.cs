using web2server.Enums;

namespace web2server.Dtos
{
    public class VerificationResponseDto
    {
        public long Id { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
    }
}

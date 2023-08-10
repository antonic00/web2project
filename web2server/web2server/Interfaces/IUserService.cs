using web2server.Dtos;

namespace web2server.Interfaces
{
    public interface IUserService
    {
        List<UserResponseDto> GetAllUsers();
        UserResponseDto GetUserById(long id);
        UserResponseDto RegisterUser(RegisterRequestDto requestDto);
        UserResponseDto UpdateUser(long id, UserRequestDto requestDto);
        LoginResponseDto LoginUser(LoginRequestDto requestDto);
        UserResponseDto VerifyUser(VerifyDto verifyDto);
    }
}

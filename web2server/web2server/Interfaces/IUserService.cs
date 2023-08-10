using web2server.Dtos;

namespace web2server.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();
        UserDto GetUserById(long id);
        UserDto RegisterUser(UserDto userDto);
        UserDto UpdateUser(long id, UserDto userDto);
        LoginResponseDto LoginUser(LoginRequestDto requestDto);
        UserDto VerifyUser(VerifyDto verifyDto);
    }
}

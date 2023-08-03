using Microsoft.AspNetCore.Mvc;
using web2server.Dtos;
using web2server.Interfaces;

namespace web2server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(long id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] UserDto userDto)
        {
            return Ok(_userService.RegisterUser(userDto));
        }

        [HttpPut]
        public IActionResult UpadateUser(long id, [FromBody] UserDto userDto)
        {
            return Ok(_userService.UpdateUser(id, userDto));
        }
    }
}

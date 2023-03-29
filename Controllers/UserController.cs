using RestaurantWebAPI.ExternalModels;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebAPI.Services.Managers;

namespace RestaurantWebAPI.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        [Route("{id}", Name = "GetUser")]
        public IActionResult GetUser(Guid id)
        {
            var userEntity = _userService.GetUser(id);
            if (userEntity == null)
            {
                return NotFound();
            }
            return Ok(userEntity);
        }
        [HttpGet]
        [Route("", Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var userEntities = _userService.GetAllUsers();
            if (userEntities == null)
            {
                return NotFound();
            }
            return Ok(userEntities);
        }
        [Route("Register", Name = "Register new account")]
        [HttpPost]
        public IActionResult Register([FromBody] UserDTO user)
        {
            var userEntity = _userService.AddUser(user);

            return CreatedAtRoute("GetUser",
                new { id = userEntity.ID },
                userEntity);
        }

    }
}

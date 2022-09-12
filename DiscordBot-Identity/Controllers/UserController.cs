using DiscordBot_Identity.Models;
using DiscordBot_Identity.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscordBot_Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsersList()
        {
            return await _userService.GetUsersList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> GetUserById(Guid id)
        {
            return await _userService.GetUserById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<User> AddUser([FromBody] User user)
        {
            return await _userService.AddUser(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<User> UpdateUser([FromBody] User user)
        {
            return await _userService.UpdateUser(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _userService.DeleteUserById(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajeros.Data.DTO;
using Viajeros.Data.Models;
using Viajeros.Services;

namespace Viajeros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserService userService) : ControllerBase
    {

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await userService.GetUsersAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            //_context.Entry(user).State = EntityState.Modified;

            try
            {
                await userService.UpdateUserAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            await userService.AddUserAsync(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await userService.DeleteUserAsync(user);

            return NoContent();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO model)
        {
            var user = await userService.LoginAsync(model.UserName, model.Password);
            if (user != null)
            {
                var response = new
                {
                    IsAuthenticated = true,
                    user.Token
                };
                return Ok(response);
            }
            return BadRequest("Error en la autenticación del usuario.");
        }
        private bool UserExists(int id)
        {
            return userService.GetUsers().Any(e => e.Id == id);
        }
    }
}

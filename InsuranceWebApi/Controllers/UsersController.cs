using InsuranceWebApi.Interfaces;
using InsuranceWebApi.Logger;
using InsuranceWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("Find/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("Find/All")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            if (users == null)
                return NotFound();

            if (users.Any())
                return NoContent();

            return Ok(users);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertUser([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.InsertUser(user);

                if (!result)
                    return StatusCode(500);

                CustomLogger.Instance.Info($"User {user.ID} succussfully inserted to the db");
                return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.UpdateUser(user);

                if (!result)
                    return StatusCode(500);

                CustomLogger.Instance.Info($"User {id} updated succussfully");
                return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var isDeleted = await _userService.DeleteUserById(id);

            if (!isDeleted)
                return NotFound();

            CustomLogger.Instance.Info($"User {id} deleted succussfully");
            return Ok(isDeleted);
        }
    }
}

using Group3.Entities;
using Group3.Services;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UserController()
        {
            _userServices = new UserServices();
        }

        // GET: /User
        [HttpGet]
        public Tuple<List<Student>, List<Professor>> GetStudentContexts()
        {
            return _userServices.GetUsers();
        }

        //POST: /User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            return await _userServices.AddUser(User);
        }

        // PUT: /User/UserId
        [HttpPut("{UserId}")]
        public async Task<IActionResult> PutUser(int UserId, User user)
        {
            if (UserId != user.UsuarioId)
            {
                return BadRequest();
            }
            else
            {
                await _userServices.UpdateUser(user);
                return Ok();
            }
        }


        // DELETE: /User/UserId
        [HttpDelete("{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            if (UserExists(UserId))
            {
                _userServices.DeleteUser(UserId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool UserExists(int UserId)
        {
            return (_userServices.GetUsers().Item1.Any(e => e.UsuarioId == UserId) || _userServices.GetUsers().Item2.Any(e => e.UsuarioId == UserId));
        }
    }
}

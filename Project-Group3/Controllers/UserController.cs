using Group3.Entities;
using Group3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [Authorize]
        [Authorize(Roles = "professor,administrator")]
        public List<User> Get()
        {
            return _userServices.Get();
        }

        // GET: /User/role
        [HttpGet("{role}")]
        [Authorize]
        [Authorize(Roles = "professor,administrator")]
        public List<User> Get(string role)
        {
            return _userServices.Get();
        }

        //POST: /User
        [HttpPost]
        //[Authorize(Roles = "administrator")]
        public async Task<ActionResult<User>> Post(User User)
        {
            return await _userServices.Add(User);
        }

        // PUT: /User/UserId
        [HttpPut("{UserId}")]
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Put(Guid UserId, User user)
        {
            if (UserId != user.UserId)
            {
                return BadRequest();
            }
            else
            {
                await _userServices.Update(user);
                return Ok();
            }
        }

        // DELETE: /User/UserId
        [HttpDelete("{id}")]
        [Authorize(Roles = "professor,administrator")]
        public IActionResult Delete(Guid id)
        {
            if (_userServices.UserExists(id))
            {
                _userServices.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

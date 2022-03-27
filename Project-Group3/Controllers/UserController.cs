using Group3.Entities;
using Group3.Services;
using Microsoft.AspNetCore.Mvc;
using Services;
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
        public Tuple<List<Student>, List<Professor>> GetStudentContexts()
        {
            return _userServices.GetUsers();
        }

        //GET: /User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            return await _userServices.AddUser(User);
        }        
    }
}

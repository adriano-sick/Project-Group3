using Group3.Entities;
using Group3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentServices _studentServices;

        public StudentController()
        {
            _studentServices = new StudentServices();
        }

        // GET: /Student
        [HttpGet]
        public List<Student> GetStudentContexts()
        {
            var studentList = _studentServices.GetStudent();
            return studentList;
        }

        // POST: /Student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student Student)
        {
            if (!UserExists(Student.UsuarioId))
            {
                return await _studentServices.AddStudent(Student);
            }
            else
            {
                return null;
            }
        }

        // PUT: /Student
        [HttpPut("{StudentId}")]
        public async Task<IActionResult> PutStudent(Guid StudentId, Student student)
        {
            if (StudentId != student.StudentId)
            {
                return BadRequest();
            }
            else
            {
                await _studentServices.UpdateStudent(student);
                return Ok();
            }
        }

        // DELETE:
        [HttpDelete("{UsuarioId}")]
        public IActionResult DeleteStudent(int UsuarioId)
        {
            if (UserExists(UsuarioId))
            {
                _studentServices.DeleteStudent(UsuarioId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool UserExists(int id)
        {
            return _studentServices.GetStudent().Any(e => e.UsuarioId == id);
        }
    }
}

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
        public async Task<IActionResult> PutStudent(int StudentId, Student student)
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
        public async Task<IActionResult> DeleteStudent(Guid UsuarioId)
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

        private bool UserExists(Guid id)
        {
            return _studentServices.GetStudent().Any(e => e.UsuarioId == id);
        }
    }
}

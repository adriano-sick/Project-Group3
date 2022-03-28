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
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorServices _professorServices;

        public ProfessorController()
        {
            _professorServices = new ProfessorServices();
        }

        // GET: /Professor
        [HttpGet]
        public List<Professor> GetProfessorContexts()
        {
            var professorList = _professorServices.GetProfessor();
            return professorList;
        }

        // POST: /Professor
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
            if (!UserExists(professor.ProfessorId))
            {
                return await _professorServices.AddProfessor(professor);
            }
            else
            {
                return null;
            }
        }

        // PUT: /Professor
        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> PutProfessor(Guid ProfessorId, Professor professor)
        {
            if (ProfessorId != professor.ProfessorId)
            {
                return BadRequest();
            }
            else
            {
                await _professorServices.UpdateProfessor(professor);
                return Ok();
            }
        }


        // DELETE:
        [HttpDelete("{UsuarioId}")]
        public IActionResult DeleteProfessor(Guid UsuarioId)
        {
            if (UserExists(UsuarioId))
            {
                _professorServices.DeleteProfessor(UsuarioId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool UserExists(Guid id)
        {
            return _professorServices.GetProfessor().Any(e => e.ProfessorId == id);
        }
    }
}

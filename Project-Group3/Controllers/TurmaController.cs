using Group3.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Group3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly TurmaServices _turmaServices;

        public TurmaController()
        {
            _turmaServices = new TurmaServices();
        }

        // GET: /Turma
        [HttpGet]
        public List<Turma> GetAvaliacoes()
        {
            return _turmaServices.GetTurmas();
        }

        //GET: /Turma
        [HttpPost]
        public async Task<ActionResult<Turma>> PostUser(Turma turma)
        {
            return await _turmaServices.AddTurma(turma);
        }

        // PUT: /Turma/TurmaId
        [HttpPut("{TurmaId}")]
        public async Task<IActionResult> PutTurma(int TurmaId, Turma turma)
        {
            if (TurmaId != turma.TurmaId)
            {
                return BadRequest();
            }
            else
            {
                await _turmaServices.UpdateTurma(turma);
                return Ok();
            }
        }


        // DELETE: /Turma/TurmaId
        [HttpDelete("{TurmaId}")]
        public IActionResult DeleteTurma(int TurmaId)
        {
            if (TurmaExists(TurmaId))
            {
                _turmaServices.DeleteTurma(TurmaId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool TurmaExists(int turmaId)
        {
            return _turmaServices.GetTurmas().Any(e => e.TurmaId == turmaId);
        }
    }
}

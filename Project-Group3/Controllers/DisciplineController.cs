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
    public class DisciplineController : ControllerBase
    {
        private readonly DisciplineServices _disciplineServices;

        public DisciplineController()
        {
            _disciplineServices = new DisciplineServices();
        }

        // GET: /Discipline
        [HttpGet]
        public List<Discipline> GetDiscipline()
        {
            return _disciplineServices.GetDisciplines();
        }

        //POST: /Discipline
        [HttpPost]
        public async Task<ActionResult<Discipline>> PostUser(Discipline discipline)
        {
            return await _disciplineServices.AddDiscipline(discipline);
        }

        // PUT: /Discipline/DisciplineId
        [HttpPut("{DisciplinaId}")]
        public async Task<IActionResult> PutDiscipline(int DisciplinaId, Discipline discipline)
        {
            if (DisciplinaId != discipline.DisciplinaId)
            {
                return BadRequest();
            }
            else
            {
                await _disciplineServices.UpdateDiscipline(discipline);
                return Ok();
            }
        }


        // DELETE: /Discipline/DisciplineId
        [HttpDelete("{DisciplinaId}")]
        public IActionResult DeleteDiscipline(int DisciplinaId)
        {
            if (DisciplineExists(DisciplinaId))
            {
                _disciplineServices.DeleteDiscipline(DisciplinaId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool DisciplineExists(int id)
        {
            return _disciplineServices.GetDisciplines().Any(e => e.DisciplinaId == id);
        }
    }
}

using Group3.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
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

        //GET: /Discipline
        [HttpPost]
        public async Task<ActionResult<Discipline>> PostUser(Discipline discipline)
        {
            return await _disciplineServices.AddDiscipline(discipline);
        }
    }
}

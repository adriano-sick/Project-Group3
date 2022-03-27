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
    public class TurmaController : ControllerBase
    {
        private readonly TurmaServices _turmaServices;

        public TurmaController()
        {
            _turmaServices = new TurmaServices();
        }

        // GET: /Avaliacao
        [HttpGet]
        public List<Turma> GetAvaliacoes()
        {
            return _turmaServices.GetTurmas();
        }

        //GET: /Avaliacao
        [HttpPost]
        public async Task<ActionResult<Turma>> PostUser(Turma turma)
        {
            return await _turmaServices.AddAvaliacao(turma);
        }
    }
}

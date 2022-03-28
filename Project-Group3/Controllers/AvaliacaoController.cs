using Group3.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Group3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly AvaliacaoServices _avaliacaoServices;

        public AvaliacaoController()
        {
            _avaliacaoServices = new AvaliacaoServices();
        }

        // GET: /Avaliacao
        [HttpGet]
        public List<Avaliacao> GetAvaliacoes()
        {
            return _avaliacaoServices.GetAvaliacoes();
        }

        //POST: /Avaliacao
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostUser(Avaliacao avaliacao)
        {
            return await _avaliacaoServices.AddAvaliacao(avaliacao);
        }

        // PUT: /Avaliacao/AvaliacaoId
        [HttpPut("{AvaliacaoId}")]
        public async Task<IActionResult> PutAvaliacao(int AvaliacaoId, Avaliacao avaliacao)
        {
            if (AvaliacaoId != avaliacao.AvaliacaoId)
            {
                return BadRequest();
            }
            else
            {
                await _avaliacaoServices.UpdateAvaliacao(avaliacao);
                return Ok();
            }
        }


        // DELETE: /Avaliacao/AvaliacaoId
        [HttpDelete("{AvaliacaoId}")]
        public IActionResult DeleteProfessor(int AvaliacaoId)
        {
            if (AvaliacaoExists(AvaliacaoId))
            {
                _avaliacaoServices.DeleteAvaliacao(AvaliacaoId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool AvaliacaoExists(int id)
        {
            return _avaliacaoServices.GetAvaliacoes().Any(e => e.AvaliacaoId == id);
        }
    }
}

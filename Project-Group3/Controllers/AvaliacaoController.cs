using Group3.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
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

        //GET: /Avaliacao
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostUser(Avaliacao avaliacao)
        {
            return await _avaliacaoServices.AddAvaliacao(avaliacao);
        }
    }
}

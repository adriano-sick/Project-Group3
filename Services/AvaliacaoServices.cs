using Group3.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class AvaliacaoServices
    {
        private readonly AvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoServices()
        {
            _avaliacaoRepository = new AvaliacaoRepository();
        }
       
        public List<Avaliacao> GetAvaliacoes()
        {
            try
            {
                var list = _avaliacaoRepository.GetAvaliacoes();
                return list;
            }
            catch (Exception)
            {
                return new();
            }
        }

        public async Task<Avaliacao> AddAvaliacao(Avaliacao avaliacao)
        {
            return await _avaliacaoRepository.AddAvaliacao(avaliacao);
        }
    }
}


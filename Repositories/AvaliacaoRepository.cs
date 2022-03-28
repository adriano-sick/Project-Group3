using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class AvaliacaoRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public AvaliacaoRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public List<Avaliacao> GetAvaliacoes()
        {
            return _entitiesContext.Avaliacao.ToList();
        }

        public async Task<Avaliacao> AddAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(avaliacao);
                await _entitiesContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public async Task<Avaliacao> UpdateAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                var result = _entitiesContext.Update(avaliacao);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error while updating changes: " + e);
                return null;
            }
        }

        public Avaliacao DeleteAvaliacao(int AvaliacaoId)
        {
            var avaliacaoDel = _entitiesContext.Avaliacao.FirstOrDefault(a => a.AvaliacaoId == AvaliacaoId);
            _entitiesContext.Remove(avaliacaoDel);
            _entitiesContext.SaveChangesAsync();
            return avaliacaoDel;
        }
    }
}

using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TurmaRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public TurmaRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public List<Turma> GetTurmas()
        {
            return _entitiesContext.Turma.ToList();
        }

        public async Task<Turma> AddTurma(Turma turma)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(turma);
                await _entitiesContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public async Task<Turma> UpdateTurma(Turma turma)
        {
            try
            {
                var result = _entitiesContext.Update(turma);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error while updating changes: " + e);
                return null;
            }
        }

        public Turma DeleteTurma(int turmaId)
        {
            var turmaDel = _entitiesContext.Turma.FirstOrDefault(a => a.TurmaId == turmaId);
            _entitiesContext.Remove(turmaDel);
            _entitiesContext.SaveChangesAsync();
            return turmaDel;
        }
    }
}

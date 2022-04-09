using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Repositories
{
    public class AlternativeRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public AlternativeRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public List<Alternative> Get(Guid questionid)
        {
            var alternative = _entitiesContext.Alternative.ToList();
            return alternative.Where(x => x.QuestionId == questionid).ToList();
        }

        public List<Alternative> Get()
        {
            return _entitiesContext.Alternative.ToList();
        }

        public async Task<Alternative> Add(Alternative alternative)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(alternative);
                await _entitiesContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public async Task<Alternative> Update(Alternative alternative)
        {
            try
            {
                var result = _entitiesContext.Update(alternative);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public Alternative Delete(Guid id)
        {
            var alternativeDel = _entitiesContext.Alternative.FirstOrDefault(a => a.AlternativeId == id);
            _entitiesContext.Remove(alternativeDel);
            _entitiesContext.SaveChangesAsync();
            return alternativeDel;
        }
    }
}

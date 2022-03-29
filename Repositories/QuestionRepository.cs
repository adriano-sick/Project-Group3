using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Repositories
{
    public class QuestionRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public QuestionRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public Question Get(Guid id)
        {
            var question = _entitiesContext.Question.ToList();
            return question.Where(x => x.QuestionId == id).FirstOrDefault();
        }

        public List<Question> Get()
        {
            return _entitiesContext.Question.ToList();
        }

        public async Task<Question> Add(Question question)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(question);
                await _entitiesContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public async Task<Question> Update(Question question)
        {
            try
            {
                var result = _entitiesContext.Update(question);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public Question Delete(Guid id)
        {
            var questionDel = _entitiesContext.Question.FirstOrDefault(a => a.QuestionId == id);
            _entitiesContext.Remove(questionDel);
            _entitiesContext.SaveChangesAsync();
            return questionDel;
        }
    }
}

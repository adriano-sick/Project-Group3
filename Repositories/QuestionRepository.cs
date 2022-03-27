using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class QuestionRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public QuestionRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public List<Question> GetQuestions()
        {
            return _entitiesContext.Question.ToList();
        }

        public async Task<Question> AddQuestion(Question question)
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
    }
}

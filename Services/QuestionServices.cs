using Group3.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class QuestionServices
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionServices()
        {
            _questionRepository = new QuestionRepository();
        }

        public List<Question> GetQuestions()
        {
            try
            {
                var list = _questionRepository.GetQuestions();
                return list;
            }
            catch (Exception)
            {
                return new();
            }
        }

        public async Task<Question> AddQuestion(Question question)
        {
            return await _questionRepository.AddQuestion(question);
        }
    }
}

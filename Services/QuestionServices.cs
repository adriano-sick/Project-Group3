using Group3.Entities;
using Group3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Services
{
    public class QuestionServices
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionServices()
        {
            _questionRepository = new QuestionRepository();
        }

        public Question Get(Guid id)
        {
            try
            {
                return _questionRepository.Get(id);
            }
            catch (Exception)
            {
                return new();
            }
        }

        public List<Question> Get()
        {
            return _questionRepository.Get();
        }

        public async Task<ActionResult<Question>> Add(Question question)
        {
            return await _questionRepository.Add(question);

        }

        public async Task<Question> Update(Question question)
        {
            return await _questionRepository.Update(question);
        }

        public Question Delete(Guid id)
        {

            return _questionRepository.Delete(id);
        }

        public bool QuestionExists(Guid id)
        {
            return _questionRepository.Get().Any(e => e.QuestionId == id);
        }
    }
}

using Group3.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Group3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionServices _questionServices;

        public QuestionController()
        {
            _questionServices = new QuestionServices();
        }

        // GET: /Discipline
        [HttpGet]
        public List<Question> GetQuestions()
        {
            return _questionServices.GetQuestions();
        }

        //GET: /Discipline
        [HttpPost]
        public async Task<ActionResult<Question>> PostUser(Question question)
        {
            return await _questionServices.AddQuestion(question);
        }
    }
}

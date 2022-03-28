using Group3.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Linq;
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

        // GET: /Question
        [HttpGet]
        public List<Question> GetQuestions()
        {
            return _questionServices.GetQuestions();
        }

        //POST: /Question
        [HttpPost]
        public async Task<ActionResult<Question>> PostUser(Question question)
        {
            return await _questionServices.AddQuestion(question);
        }

        // PUT: /Question/questionId
        [HttpPut("{questionId}")]
        public async Task<IActionResult> PutQuestion(int questionId, Question question)
        {
            if (questionId != question.QuestionId)
            {
                return BadRequest();
            }
            else
            {
                await _questionServices.UpdateQuestion(question);
                return Ok();
            }
        }


        // DELETE: /Question/QuestionId
        [HttpDelete("{QuestionId}")]
        public IActionResult DeleteQuestion(int QuestionId)
        {
            if (QuestionExists(QuestionId))
            {
                _questionServices.DeleteQuestion(QuestionId);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        private bool QuestionExists(int QuestionId)
        {
            return _questionServices.GetQuestions().Any(e => e.QuestionId == QuestionId);
        }
    }
}

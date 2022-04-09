using Group3.Entities;
using Group3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group3.Controllers
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
        [Authorize(Roles = "professor,administrator,student")]
        public List<Question> Get()
        {
            return _questionServices.Get();
        }

        // GET: /Question/TestId
        [HttpGet("{testId}")]
        [Authorize(Roles = "professor,administrator,student")]
        public List<Question> Get(Guid testId)
        {
            return _questionServices.Get();
        }

        //POST: /Question
        [HttpPost]
        [Authorize(Roles = "professor,administrator")]
        public async Task<ActionResult<Question>> Post(Question question)
        {
            return await _questionServices.Add(question);
        }

        // PUT: /Question/QuestionId
        [HttpPut("{Id}")]
        [Authorize(Roles = "professor,administrator")]
        public async Task<IActionResult> Put(Guid id, Question question)
        {
            if (id != question.QuestionId)
            {
                return BadRequest();
            }
            else
            {
                await _questionServices.Update(question);
                return Ok();
            }
        }

        // DELETE: /Question/QuestionId
        [HttpDelete("{id}")]
        [Authorize(Roles = "professor,administrator")]
        public IActionResult Delete(Guid id)
        {
            if (_questionServices.QuestionExists(id))
            {
                _questionServices.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

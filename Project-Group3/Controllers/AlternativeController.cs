using Group3.Entities;
using Group3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlternativeController : ControllerBase
    {
        private readonly AlternativeServices _alternativeServices;

        public AlternativeController()
        {
            _alternativeServices = new AlternativeServices();
        }

        // GET: /Alternative
        [HttpGet]
        [Authorize(Roles = "professor,administrator,student")]
        public List<Alternative> Get()
        {
            return _alternativeServices.Get();
        }

        // GET: /Alternative/questionId
        [HttpGet("{questionId}")]
        [Authorize(Roles = "professor,administrator,student")]
        public List<Alternative> Get(Guid questionId)
        {
            return _alternativeServices.Get(questionId);
        }

        //POST: /Alternative
        [HttpPost]
        [Authorize(Roles = "professor,administrator")]
        public async Task<ActionResult<Alternative>> Post(Alternative alternative)
        {
            return await _alternativeServices.Add(alternative);
        }

        // PUT: /Alternative/AlternativeId
        [HttpPut("{id}")]
        [Authorize(Roles = "professor,administrator")]
        public async Task<IActionResult> Put(Guid id, Alternative alternative)
        {
            if (id != alternative.AlternativeId)
            {
                return BadRequest();
            }
            else
            {
                await _alternativeServices.Update(alternative);
                return Ok();
            }
        }


        // DELETE: /Alternative/AlternativeId
        [HttpDelete("{id}")]
        [Authorize(Roles = "professor,administrator")]
        public IActionResult Delete(Guid id)
        {
            if (_alternativeServices.AlternativeExists(id))
            {
                _alternativeServices.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

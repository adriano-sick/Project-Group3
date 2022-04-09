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
    public class TestController : ControllerBase
    {
        private readonly TestServices _testServices;

        public TestController()
        {
            _testServices = new TestServices();
        }

        // GET: /Test
        [HttpGet]
        [Authorize(Roles = "professor,student,administrator")]
        public List<Test> Get()
        {
            return _testServices.Get();
        }

        // GET: /Test/TestiId
        [HttpGet("{testId}")]
        [Authorize(Roles = "professor,student,administrator")]
        public List<Test> Get(Guid testId)
        {
            return _testServices.Get();
        }

        //POST: /Test
        [HttpPost]
        [Authorize(Roles = "professor,administrator")]
        public async Task<ActionResult<Test>> Post(Test test)
        {
            return await _testServices.Add(test);
        }

        // PUT: /Test/TestId
        [HttpPut("{id}")]
        [Authorize(Roles = "professor,administrator")]
        public async Task<IActionResult> Put(Guid id, Test test)
        {
            if (id != test.TestId)
            {
                return BadRequest();
            }
            else
            {
                await _testServices.Update(test);
                return Ok();
            }
        }

        // DELETE: /Test/TestId
        [HttpDelete("{id}")]
        [Authorize(Roles = "professor,administrator")]
        public IActionResult Delete(Guid id)
        {
            if (_testServices.TestExists(id))
            {
                _testServices.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

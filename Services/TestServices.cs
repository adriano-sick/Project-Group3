using Group3.Entities;
using Group3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Services
{
    public class TestServices
    {
        private readonly TestRepository _testRepository;

        public TestServices()
        {
            _testRepository = new TestRepository();
        }

        public Test Get(Guid id)
        {
            try
            {
                return _testRepository.Get(id);
            }
            catch (Exception)
            {
                return new();
            }
        }

        public List<Test> Get()
        {
            return _testRepository.Get();
        }

        public async Task<ActionResult<Test>> Add(Test test)
        {
            return await _testRepository.Add(test);

        }

        public async Task<Test> Update(Test test)
        {
            return await _testRepository.Update(test);
        }

        public Test Delete(Guid id)
        {
            return _testRepository.Delete(id);
        }

        public bool TestExists(Guid id)
        {
            return _testRepository.Get().Any(e => e.TestId == id);
        }
    }
}

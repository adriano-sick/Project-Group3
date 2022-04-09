using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Repositories
{
    public class TestRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public TestRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        //public Test Get(Guid id)
        //{
        //    var test = _entitiesContext.Test.ToList();
        //    return test.Where(x => x.TestId == id).FirstOrDefault();
        //}

        public List<Test> Get(Guid UserId)
        {
            var test = _entitiesContext.Test.ToList();
            return test.Where(x => x.UserId == UserId).ToList();
        }

        public List<Test> Get()
        {
            return _entitiesContext.Test.ToList();
        }

        public async Task<Test> Add(Test test)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(test);
                await _entitiesContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public async Task<Test> Update(Test test)
        {
            try
            {
                var result = _entitiesContext.Update(test);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public Test Delete(Guid id)
        {
            var testDel = _entitiesContext.Test.FirstOrDefault(a => a.TestId == id);
            _entitiesContext.Remove(testDel);
            _entitiesContext.SaveChangesAsync();
            return testDel;
        }
    }
}

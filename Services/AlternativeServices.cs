using Group3.Entities;
using Group3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Services
{
    public class AlternativeServices
    {
        private readonly AlternativeRepository _alternativeRepository;

        public AlternativeServices()
        {
            _alternativeRepository = new AlternativeRepository();
        }

        public Alternative Get(Guid id)
        {
            try
            {
                return _alternativeRepository.Get(id);
            }
            catch (Exception)
            {
                return new();
            }
        }

        public List<Alternative> Get()
        {
            return _alternativeRepository.Get();
        }

        public async Task<ActionResult<Alternative>> Add(Alternative alternative)
        {
            return await _alternativeRepository.Add(alternative);

        }

        public async Task<Alternative> Update(Alternative alternative)
        {
            return await _alternativeRepository.Update(alternative);
        }

        public Alternative Delete(Guid id)
        {

            return _alternativeRepository.Delete(id);
        }

        public bool AlternativeExists(Guid id)
        {
            return _alternativeRepository.Get().Any(e => e.AlternativeId == id);
        }
    }
}

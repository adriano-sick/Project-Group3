using Group3.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class DisciplineServices
    {
        private readonly DisciplineRepository _disciplineRepository;

        public DisciplineServices()
        {
            _disciplineRepository = new DisciplineRepository();
        }

        public List<Discipline> GetDisciplines()
        {
            try
            {
                var list = _disciplineRepository.GetDisciplines();
                return list;
            }
            catch (Exception)
            {
                return new();
            }
        }

        public async Task<Discipline> AddDiscipline(Discipline discipline)
        {
            return await _disciplineRepository.AddDiscipline(discipline);
        }

        public async Task<Discipline> UpdateDiscipline(Discipline discipline)
        {
            return await _disciplineRepository.UpdateDiscipline(discipline);
        }

        public Discipline DeleteDiscipline(int DisciplinaId)
        {
            return _disciplineRepository.DeleteDiscipline(DisciplinaId);
        }
    }
}


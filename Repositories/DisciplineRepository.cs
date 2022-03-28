﻿using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DisciplineRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public DisciplineRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public List<Discipline> GetDisciplines()
        {
            return _entitiesContext.Discipline.ToList();
        }

        public async Task<Discipline> AddDiscipline(Discipline discipline)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(discipline);
                await _entitiesContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }
    }
}
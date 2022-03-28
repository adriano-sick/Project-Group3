using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Repository
{
    public class ProfessorRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public ProfessorRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public List<Professor> GetProfessors()
        {
            return _entitiesContext.Professor.ToList();
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(professor);
                await _entitiesContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);  
                return null;
            }
        } 

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            try
            {
                var result = _entitiesContext.Update(professor);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("Error while updating changes: " + e);
                return null;
            }
        }

        public Professor DeleteProfessor(Guid ProfessorId)
        {
            var professorDel = _entitiesContext.Professor.FirstOrDefault(a => a.ProfessorId == ProfessorId);
            _entitiesContext.Remove(professorDel);
            _entitiesContext.SaveChangesAsync();
            return professorDel;
        }
    }
}

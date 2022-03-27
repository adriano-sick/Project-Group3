using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Repository
{
    public class ProfessorRepository
    {
        private readonly ProfessorContext _professorContext;

        public ProfessorRepository()
        {
            _professorContext = new ProfessorContext();
        }

        public List<Professor> GetProfessors()
        {
            return _professorContext.Professor.ToList();
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            try
            {
                var result = await _professorContext.AddAsync(professor);
                await _professorContext.SaveChangesAsync();

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
                var result = _professorContext.Update(professor);
                await _professorContext.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("Error while updating changes: " + e);
                return null;
            }
        }

        public Professor DeleteProfessor(Guid UsuarioId)
        {
            var professorDel = _professorContext.Professor.FirstOrDefault(a => a.UsuarioId == UsuarioId);
            _professorContext.Remove(professorDel);
            _professorContext.SaveChangesAsync();
            return professorDel;
        }
    }
}

using Group3.Entities;
using Group3.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group3.Services
{
    public class ProfessorServices
    {
        private readonly ProfessorRepository _professorRepository;

        public ProfessorServices()
        {
            _professorRepository = new ProfessorRepository();
        }

        public List<Professor> GetProfessor()
        {
            try
            {
                var list = _professorRepository.GetProfessors();
                return list;
            }
            catch (Exception)
            {
                return new();
            }
        }

        public async Task<Professor> AddProfessor(Professor professor)
        {
            return await _professorRepository.AddProfessor(professor);
        }

        public async Task<Professor> UpdateProfessor(Professor professor)
        {
            return await _professorRepository.UpdateProfessor(professor);
        }

        public Professor DeleteProfessor(Guid UsuarioId)
        {
            return _professorRepository.DeleteProfessor(UsuarioId);
        }
    }
}

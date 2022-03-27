using Group3.Entities;
using Group3.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group3.Services
{
    public class StudentServices
    {
        private readonly StudentRepository _studentRepository;

        public StudentServices()
        {
            _studentRepository = new StudentRepository();
        }

        public List<Student> GetStudent()
        {
            try
            {
                var list = _studentRepository.GetStudents();
                return list;
            }
            catch (Exception)
            {
                return new();
            }
        }

        public async Task<Student> AddStudent(Student student)
        {
            return await _studentRepository.AddStudent(student);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            return await _studentRepository.UpdateStudent(student);
        }

        public Student DeleteStudent(Guid UsuarioId)
        {
            return _studentRepository.DeleteStudent(UsuarioId);
        }
    }
}

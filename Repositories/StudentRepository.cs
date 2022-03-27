using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Repository
{
    public class StudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository()
        {
            _studentContext = new StudentContext();
        }

        public List<Student> GetStudents()
        {
            return _studentContext.Student.ToList();
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                var result = await _studentContext.AddAsync(student);
                await _studentContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);  
                return null;
            }
        } 

        public async Task<Student> UpdateStudent(Student student)
        {
            try
            {
                var result = _studentContext.Update(student);
                await _studentContext.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("Error while updating changes: " + e);
                return null;
            }
        }

        public Student DeleteStudent(Guid UsuarioId)
        {
            var studentDel = _studentContext.Student.FirstOrDefault(a => a.UsuarioId == UsuarioId);
            _studentContext.Remove(studentDel);
            _studentContext.SaveChangesAsync();
            return studentDel;
        }
    }
}

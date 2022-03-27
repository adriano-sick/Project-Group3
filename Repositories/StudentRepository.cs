using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Repository
{
    public class StudentRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public StudentRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public List<Student> GetStudents()
        {
            return _entitiesContext.Student.ToList();
        }

        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(student);
                await _entitiesContext.SaveChangesAsync();

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
                var result = _entitiesContext.Update(student);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("Error while updating changes: " + e);
                return null;
            }
        }

        public Student DeleteStudent(int UsuarioId)
        {
            var studentDel = _entitiesContext.Student.FirstOrDefault(a => a.UsuarioId == UsuarioId);
            _entitiesContext.Remove(studentDel);
            _entitiesContext.SaveChangesAsync();
            return studentDel;
        }
    }
}

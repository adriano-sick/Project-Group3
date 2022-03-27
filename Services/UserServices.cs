using Group3.Entities;
using Group3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public class UserServices
    {
        private readonly StudentServices _studentServices;
        private readonly ProfessorServices _professorService;

        public UserServices()
        {
            _studentServices = new StudentServices();
            _professorService = new ProfessorServices();
        }

        public Tuple<List<Student>, List<Professor>> GetUsers()
        {            
            try
            {
                var studentList = _studentServices.GetStudent();
                var professorList = _professorService.GetProfessor();
                return new Tuple<List<Student>, List<Professor>>(studentList, professorList);
            }
            catch (Exception)
            {
                return new Tuple<List<Student>, List<Professor>>(new List<Student>(), new List<Professor>());
            }
        }

        public async Task<ActionResult<User>> AddUser(User User)
        {
            if (User.Ocupacao == "student")
            {
                Student Student = new()
                {
                    Nome = User.Nome,
                    Senha = User.Senha,
                    Email = User.Email,
                    DataNasc = User.DataNasc,
                    Endereco = User.Endereco,
                    Numero = User.Numero,
                    Bairro = User.Bairro,
                    Cidade = User.Cidade,
                    Estado = User.Estado,
                    Cep = User.Cep,
                    Ocupacao = User.Ocupacao
                };

                if (!UserExists(User.UsuarioId))
                {
                    return await _studentServices.AddStudent(Student);
                }
                else
                {
                    return null;
                }
            }
            else if (User.Ocupacao == "professor")
            {
                Professor Professor = new()
                {
                    Nome = User.Nome,
                    Senha = User.Senha,
                    Email = User.Email,
                    DataNasc = User.DataNasc,
                    Endereco = User.Endereco,
                    Numero = User.Numero,
                    Bairro = User.Bairro,
                    Cidade = User.Cidade,
                    Estado = User.Estado,
                    Cep = User.Cep,
                    Ocupacao = User.Ocupacao
                };

                if (!UserExists(User.UsuarioId))
                {
                    return await _professorService.AddProfessor(Professor);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }




        private bool UserExists(int id)
        {
            return _studentServices.GetStudent().Any(e => e.UsuarioId == id);
        }
    }
}

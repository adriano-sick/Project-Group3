using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Entities
{
    public class Professor : User
    {   
        public Guid ProfessorId { get; set; } = Guid.NewGuid();
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Entities
{
    public class Professor : User
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfessorId { get; set; }
        [ForeignKey("UsuarioId")]
        public User User { get; set; }
    }
}

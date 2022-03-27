using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Entities
{
    public class Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DisciplinaId { get; set; }
        public string DisciplinaName { get; set; }
        [ForeignKey("UsuarioId")]
        public Professor Professor { get; set; }
        [ForeignKey("TurmaId")]
        public Turma Turma { get; set; }
    }

}

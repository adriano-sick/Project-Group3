using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Entities
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string QuestionEnunciado { get; set; }
        public bool QuestionCorreta { get; set; }
        [ForeignKey("AvaliacaoId")]
        public Avaliacao Avaliacao { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Entities
{
    public class Alternative
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AlternativeId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        [ForeignKey("QuestionId")]
        public Guid QuestionId { get; set; }
    }
}

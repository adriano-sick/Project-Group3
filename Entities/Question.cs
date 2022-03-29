﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Entities
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid QuestionId { get; set; }
        public string Title { get; set; }
        [ForeignKey("TestId")]
        public Test Test { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

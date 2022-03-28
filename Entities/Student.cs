using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Entities
{
    public class Student : User
    {
        public Guid StudentId { get; set; } = Guid.NewGuid();
    }
}

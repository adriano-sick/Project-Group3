using Microsoft.EntityFrameworkCore;
using System;

namespace Group3.Entities
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> contextOptions) : base(contextOptions)
        {
        }

        public EntitiesContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("Production"));
        }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<User> User { get; set; }
    }
}

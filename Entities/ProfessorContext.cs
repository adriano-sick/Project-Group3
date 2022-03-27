using Microsoft.EntityFrameworkCore;

namespace Group3.Entities
{
    public class ProfessorContext : DbContext
    {
        public ProfessorContext(DbContextOptions<ProfessorContext> contextOptions) : base(contextOptions)
        {
        }

        public ProfessorContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Group03.mssql.somee.com; Database=Group03; User Id=adrianosiqueira_SQLLogin_1; Password=j1fzzgtol5;");
        }
        
        public DbSet<Professor> Professor { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Group3.Entities
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> contextOptions) : base(contextOptions)
        {
        }

        public StudentContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Group03.mssql.somee.com; Database=Group03; User Id=adrianosiqueira_SQLLogin_1; Password=j1fzzgtol5;");
        }
        public DbSet<Student> Student{ get; set; }
    }
}

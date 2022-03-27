using Microsoft.EntityFrameworkCore;

namespace Group3.Entities
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> contextOptions) : base(contextOptions)
        {
        }

        public UserContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Group03.mssql.somee.com; Database=Group03; User Id=adrianosiqueira_SQLLogin_1; Password=j1fzzgtol5;");
        }
        public DbSet<User> User { get; set; }
    }
}

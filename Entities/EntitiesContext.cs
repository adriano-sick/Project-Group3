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
        public DbSet<User> User { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Alternative> Alternative { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}

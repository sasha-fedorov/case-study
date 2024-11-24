using Microsoft.EntityFrameworkCore;
using CaseStudy.Data.Entities.Books;
using CaseStudy.Data.Entities.Collections;
using CaseStudy.Data.Mapping;

namespace CaseStudy.Data
{
    public class CaseStudyApplicationContext : DbContext
    {
        public CaseStudyApplicationContext() : base() { }
        public CaseStudyApplicationContext(DbContextOptions<CaseStudyApplicationContext> options) : base(options) { }
        public CaseStudyApplicationContext(string connectionString)
        {
            Connection = connectionString;
            Database.EnsureCreated();
        }

        private string Connection { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Collection> Collections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Connection);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddMappers();
            base.OnModelCreating(modelBuilder);
        }
    }
}

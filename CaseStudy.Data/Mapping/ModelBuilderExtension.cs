using Microsoft.EntityFrameworkCore;
using CaseStudy.Data.Mapping.Books;

namespace CaseStudy.Data.Mapping
{
    public static class ModelBuilderExtension
    {
        public static void AddMappers(this ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookMapper());
        }
    }
}

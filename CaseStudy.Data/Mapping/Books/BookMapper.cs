using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CaseStudy.Data.Entities.Books;
using CaseStudy.Data.Entities.Collections;
using CaseStudy.Data.Entities.Relational.BookCollections;

namespace CaseStudy.Data.Mapping.Books
{
    public class BookMapper : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> modelBuilder)
        {
            modelBuilder
                .HasMany(b => b.Collections)
                .WithMany(c => c.Books)
                .UsingEntity<BookCollection>(
                    c => c.HasOne<Collection>().WithMany().HasForeignKey(bc => bc.CollectionId),
                    b => b.HasOne<Book>().WithMany().HasForeignKey(bc => bc.BookId));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using CaseStudy.Data.Entities.Books;
using CaseStudy.Data.Entities.Collections;

namespace CaseStudy.Data.DataAccesses.Books
{
    public class BookDataAccess(CaseStudyApplicationContext applicationContext) : BaseDataAccess<Book>(applicationContext)
    {
        public new async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _appContext.Set<Book>().Include(b => b.Collections).ToListAsync(cancellationToken);
        }

        public async Task<Book> UpdateAsync(Book entity, CancellationToken cancellationToken)
        {
            entity.Modified = DateTime.Now;
            _appContext.Entry(entity).Property(nameof(Book.Title)).IsModified = true;
            _appContext.Entry(entity).Property(nameof(Book.Author)).IsModified = true;
            _appContext.Entry(entity).Property(nameof(Book.PublishYear)).IsModified = true;
            _appContext.Entry(entity).Property(nameof(Book.Genre)).IsModified = true;
            _appContext.Entry(entity).Property(nameof(Book.Modified)).IsModified = true;

            await _appContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task AddBookToCollectionAsync(Book book, Collection collection, CancellationToken cancellationToken)
        {
            book.Collections.Add(collection);

            await _appContext.SaveChangesAsync(cancellationToken);
        }
    }
}

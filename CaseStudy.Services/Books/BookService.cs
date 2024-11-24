using CaseStudy.Data.Enums;
using CaseStudy.Data.Repository;
using CaseStudy.Dto.Books;

namespace CaseStudy.Services.Books
{
    public class BookService(CaseStudyRepository repository)
    {
        private readonly CaseStudyRepository _repository = repository;

        public async Task<List<BookDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var booksDb = await _repository.BookDataAccess.GetAllAsync(cancellationToken);
            return booksDb.Select(b => b.ToDtoEntity()).ToList();
        }

        public async Task<BookDto> AddAsync(BookDto book, CancellationToken cancellationToken)
        {
            var bookDb = book.ToDbEntity();
            bookDb = await _repository.BookDataAccess.AddAsync(bookDb, cancellationToken);

            return bookDb.ToDtoEntity();
        }

        public async Task<BookDto> UpdateAsync(BookDto book, CancellationToken cancellationToken)
        {
            var bookDb = book.ToDbEntity();
            bookDb = await _repository.BookDataAccess.UpdateAsync(bookDb, cancellationToken);

            return bookDb.ToDtoEntity();
        }

        public async Task AddBookToCollectionAsync(Guid bookId, Guid collectionId, CancellationToken cancellationToken)
        {
            var bookDb = await _repository.BookDataAccess.GetByIdAsync(bookId, cancellationToken);
            var collectionDb = await _repository.CollectionDataAccess.GetByIdAsync(collectionId, cancellationToken);

            await _repository.BookDataAccess.AddBookToCollectionAsync(bookDb, collectionDb, cancellationToken);
        }

        public List<string> GetAllGenresAsync()
        {
            var genres = new List<string>();
            foreach (BookGenres genre in Enum.GetValues(typeof(BookGenres)))
            {
                genres.Add(genre.ToStringValue());
            }

            return genres;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var bookDb = await _repository.BookDataAccess.GetByIdAsync(id, cancellationToken);
            await _repository.BookDataAccess.DeleteAsync(bookDb, cancellationToken);
        }
    }
}

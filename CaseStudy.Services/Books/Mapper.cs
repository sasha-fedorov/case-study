using CaseStudy.Data.Entities.Books;
using CaseStudy.Data.Enums;
using CaseStudy.Dto.Books;

namespace CaseStudy.Services.Books
{
    public static class Mapper
    {
        public static Book ToDbEntity(this BookDto book) => 
            new()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishYear = book.PublishYear,
                Genre = book.Genre.ToEnum()
            };

        public static BookDto ToDtoEntity(this Book bookDb) =>
            new()
            {
                Id = bookDb.Id,
                Title = bookDb.Title,
                Author = bookDb.Author,
                PublishYear = bookDb.PublishYear,
                Genre = bookDb.Genre.ToStringValue(),
                Collections = bookDb.Collections?.Select(c => c.Name).ToList() ?? []
            };

        public static string ToStringValue(this BookGenres genre) => genre.ToString().Replace('_', ' ');
        private static BookGenres ToEnum(this string inGenre) => Enum.TryParse(inGenre.Replace(' ', '_'), out BookGenres genre) ? genre : BookGenres.Other;
    }
}

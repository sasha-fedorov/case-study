using CaseStudy.Data.Entities.Collections;
using CaseStudy.Data.Enums;

namespace CaseStudy.Data.Entities.Books
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public BookGenres Genre { get; set; }
        public List<Collection> Collections { get; set; } = [];
    }
}

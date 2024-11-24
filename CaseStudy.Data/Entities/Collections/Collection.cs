using CaseStudy.Data.Entities.Books;

namespace CaseStudy.Data.Entities.Collections
{
    public class Collection :BaseEntity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; } = [];
    }
}

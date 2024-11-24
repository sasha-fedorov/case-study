using CaseStudy.Data.Entities.Books;
using CaseStudy.Data.Entities.Collections;

namespace CaseStudy.Data.Entities.Relational.BookCollections
{
    public class BookCollection
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}

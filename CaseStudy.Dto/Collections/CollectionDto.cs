using CaseStudy.Dto.Books;

namespace CaseStudy.Dto.Collections
{
    public class CollectionDto : BaseDto
    {
        public string Name { get; set; }
        public List<string> Books { get; set; } = [];
    }
}

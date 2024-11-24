using CaseStudy.Dto.Collections;

namespace CaseStudy.Dto.Books
{
    public class BookDto :BaseDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public string Genre { get; set; }
        public List<string> Collections { get; set; } = [];
    }
}

using CaseStudy.Data.Entities.Collections;
using CaseStudy.Dto.Collections;

namespace CaseStudy.Services.Collections
{
    public static class Mapper
    {
        public static Collection ToDbEntity(this CollectionDto collection) =>
            new()
            {
                Id = collection.Id,
                Name = collection.Name,
            };

        public static CollectionDto ToDtoEntity(this Collection collectionDb) =>
            new ()
            {
                Id = collectionDb.Id,
                Name = collectionDb.Name,
                Books = collectionDb.Books.Select(b => b.Title).ToList() ?? []
            };
    }
}

using CaseStudy.Data.Repository;
using CaseStudy.Dto.Collections;

namespace CaseStudy.Services.Collections
{
    public class CollectionService(CaseStudyRepository repository)
    {
        private readonly CaseStudyRepository _repository = repository;

        public async Task<List<CollectionDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var collectionsDb = await _repository.CollectionDataAccess.GetAllAsync(cancellationToken);
            return collectionsDb.Select(b => b.ToDtoEntity()).ToList();
        }

        public async Task<CollectionDto> AddAsync(CollectionDto book, CancellationToken cancellationToken)
        {
            var collectionDb = book.ToDbEntity();
            collectionDb = await _repository.CollectionDataAccess.AddAsync(collectionDb, cancellationToken);

            return collectionDb.ToDtoEntity();
        }

        public async Task<CollectionDto> UpdateAsync(CollectionDto book, CancellationToken cancellationToken)
        {
            var collectionDb = book.ToDbEntity();
            collectionDb = await _repository.CollectionDataAccess.UpdateAsync(collectionDb, cancellationToken);

            return collectionDb.ToDtoEntity();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var collectionDb = await _repository.CollectionDataAccess.GetByIdAsync(id, cancellationToken);
            await _repository.CollectionDataAccess.DeleteAsync(collectionDb, cancellationToken);
        }
    }
}

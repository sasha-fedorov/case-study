using Microsoft.EntityFrameworkCore;
using CaseStudy.Data.Entities.Collections;

namespace CaseStudy.Data.DataAccesses.Collections
{
    public class CollectionDataAccess(CaseStudyApplicationContext applicationContext) : BaseDataAccess<Collection>(applicationContext)
    {
        public new async Task<List<Collection>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _appContext.Set<Collection>().Include(c => c.Books).ToListAsync(cancellationToken);
        }

        public async Task<Collection> UpdateAsync(Collection entity, CancellationToken cancellationToken)
        {
            entity.Modified = DateTime.Now;
            _appContext.Entry(entity).Property(nameof(Collection.Name)).IsModified = true;
            _appContext.Entry(entity).Property(nameof(Collection.Modified)).IsModified = true;

            await _appContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}

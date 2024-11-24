using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using CaseStudy.Data.DataAccesses.Books;
using CaseStudy.Data.DataAccesses.Collections;

namespace CaseStudy.Data.Repository
{
    public class CaseStudyRepository : IDisposable
    {
        private readonly CaseStudyApplicationContext _appContext;

        public void AddDataAccesses()
        {
            BookDataAccess = new BookDataAccess(_appContext);
            CollectionDataAccess = new CollectionDataAccess(_appContext);
        }

        public BookDataAccess BookDataAccess { get; set; }
        public CollectionDataAccess CollectionDataAccess { get; set; }

        public CaseStudyRepository(DbContextOptions<CaseStudyApplicationContext> context)
        {
            _appContext = new CaseStudyApplicationContext(context);
            AddDataAccesses();
        }

        public CaseStudyRepository(string connectionString)
        {
            _appContext = new CaseStudyApplicationContext(connectionString);
            AddDataAccesses();
        }

        public Task MigrateAsync(CancellationToken cancellationToken)
        {
            _appContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(120));
            return _appContext.Database.MigrateAsync(cancellationToken);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return _appContext.Database.BeginTransactionAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _appContext.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

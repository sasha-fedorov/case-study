using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CaseStudy.Data.Repository;
using CaseStudy.Services.Books;
using CaseStudy.Services.Collections;

namespace CaseStudy.Services
{
    public static class DependencyInjectionExtension
    {
        private const string CONNECTION_NAME = "SQLite";

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString(CONNECTION_NAME);
            services.AddScoped(c => new CaseStudyRepository(connection));

            services.AddScoped<BookService>();
            services.AddScoped<CollectionService>();

            return services;
        }
    }
}

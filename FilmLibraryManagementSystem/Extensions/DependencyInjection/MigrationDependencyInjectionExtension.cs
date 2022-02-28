using FilmLibraryManagementSystem.Migration.Database;
using Microsoft.Extensions.DependencyInjection;

namespace FilmLibraryManagementSystem.App.Extensions.DependencyInjection
{
    public static class MigrationDependencyInjectionExtension
    {
        public static void AddMigrations(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseMigrator>();
        }
    }
}

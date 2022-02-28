using FilmLibraryManagementSystem.Core.Abstraction.Services.Genres;
using FilmLibraryManagementSystem.Core.Abstraction.Services.Users;
using FilmLibraryManagementSystem.Core.Services.Films;
using FilmLibraryManagementSystem.Core.Services.Genres;
using FilmLibraryManagementSystem.Core.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FilmLibraryManagementSystem.App.Extensions.DependencyInjection
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFilmsService, FilmsService>();
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<IUsersService, UsersService>();
        }
    }
}

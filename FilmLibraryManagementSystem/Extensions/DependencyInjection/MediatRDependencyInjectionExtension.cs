using FilmLibraryManagementSystem.Core.Handlers.Films.Commands.AddFilm;
using FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetAllFilms;
using FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetFilmByTitle;
using FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetRandomFilm;
using FilmLibraryManagementSystem.Model.General.Commands;
using FilmLibraryManagementSystem.Model.General.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FilmLibraryManagementSystem.App.Extensions.DependencyInjection
{
    public static class MediatRDependencyInjectionExtension
    {
        public static void AddMediatRExtension(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }

        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddFilmCommand, AddFilmResponse>, AddFilmCommandHandler>();
        }

        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetAllFilmsQuery, GetAllFilmsResult>, GetAllFilmsHandler>();
            services.AddTransient<IRequestHandler<GetFilmByIdQuery, GetFilmByIdResult>, GetFilmByIdHandler>();
            services.AddTransient<IRequestHandler<GetRandomFilmQuery, GetRandomFilmResult>, GetRandomFilmHandler>();
            services.AddTransient<IRequestHandler<GetFilmsByTitleQuery, GetFilmsByTitleResult>, GetFilmsByTitleHandler>();
        }
    }
}

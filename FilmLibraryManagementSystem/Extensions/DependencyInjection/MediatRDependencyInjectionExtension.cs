using FilmLibraryManagementSystem.Core.Handlers.Films.Commands.AddFilm;
using FilmLibraryManagementSystem.Core.Handlers.Films.Commands.EditFilm;
using FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetAllFilms;
using FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetFilmByTitle;
using FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetRandomFilm;
using FilmLibraryManagementSystem.Core.Handlers.Genres.Commands.AddGenre;
using FilmLibraryManagementSystem.Core.Handlers.Genres.Queries.GetAllGenres;
using FilmLibraryManagementSystem.Core.Handlers.Users.Commands.AuthenticateUser;
using FilmLibraryManagementSystem.Core.Handlers.Users.Commands.RegisterUser;
using FilmLibraryManagementSystem.Model.General.Commands;
using FilmLibraryManagementSystem.Model.General.Commands.Films;
using FilmLibraryManagementSystem.Model.General.Commands.Genres;
using FilmLibraryManagementSystem.Model.General.Commands.Users;
using FilmLibraryManagementSystem.Model.General.Queries;
using FilmLibraryManagementSystem.Model.General.Queries.Genres;
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
            services.AddTransient<IRequestHandler<AddGenreCommand, AddGenreResponse>, AddGenreCommandHandler>();
            services.AddTransient<IRequestHandler<EditFilmCommand, EditFilmResponse>, EditFilmCommandHandler>();
            services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterUserResponse>, RegisterUserCommandHandler>();
            services.AddTransient<IRequestHandler<AuthenticateUserCommand, AuthenticateUserResponse>, AuthenticateUserCommandHandler>();
        }

        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetAllFilmsQuery, GetAllFilmsResult>, GetAllFilmsHandler>();
            services.AddTransient<IRequestHandler<GetFilmByIdQuery, GetFilmByIdResult>, GetFilmByIdHandler>();
            services.AddTransient<IRequestHandler<GetRandomFilmQuery, GetRandomFilmResult>, GetRandomFilmHandler>();
            services.AddTransient<IRequestHandler<GetFilmsByTitleQuery, GetFilmsByTitleResult>, GetFilmsByTitleHandler>();
            services.AddTransient<IRequestHandler<GetAllGenresQuery, GetAllGenresResult>, GetAllGenresHandler>();
        }
    }
}

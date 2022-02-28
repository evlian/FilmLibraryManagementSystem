using Pixond.Core.Handlers.Films.Commands.AddFilm;
using Pixond.Core.Handlers.Films.Commands.EditFilm;
using Pixond.Core.Handlers.Films.Queries.GetAllFilms;
using Pixond.Core.Handlers.Films.Queries.GetFilmByTitle;
using Pixond.Core.Handlers.Films.Queries.GetRandomFilm;
using Pixond.Core.Handlers.Genres.Commands.AddGenre;
using Pixond.Core.Handlers.Genres.Queries.GetAllGenres;
using Pixond.Core.Handlers.Users.Commands.AuthenticateUser;
using Pixond.Core.Handlers.Users.Commands.RegisterUser;
using Pixond.Model.General.Commands;
using Pixond.Model.General.Commands.Films;
using Pixond.Model.General.Commands.Genres;
using Pixond.Model.General.Commands.Users;
using Pixond.Model.General.Queries;
using Pixond.Model.General.Queries.Genres;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Pixond.App.Extensions.DependencyInjection
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

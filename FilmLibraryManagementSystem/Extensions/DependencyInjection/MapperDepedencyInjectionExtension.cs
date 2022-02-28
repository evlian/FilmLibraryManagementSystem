using AutoMapper;
using FilmLibraryManagementSystem.Core.Framework.Mapping.Films.Queries.GetAllFilms;
using FilmLibraryManagementSystem.Core.Framework.Mapping.Genres.Commands.AddGenre;
using Microsoft.Extensions.DependencyInjection;

namespace FilmLibraryManagementSystem.App.Extensions.DependencyInjection
{
    public static class MapperDepedencyInjectionExtension
    {

        public static void AddMappingWithProfiles(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GetAllFilmsMappings>();
                cfg.AddProfile<AddGenreMappings>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

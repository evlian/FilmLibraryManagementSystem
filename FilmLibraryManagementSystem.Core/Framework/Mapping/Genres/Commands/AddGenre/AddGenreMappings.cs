using AutoMapper;
using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Commands.Genres;

namespace FilmLibraryManagementSystem.Core.Framework.Mapping.Genres.Commands.AddGenre
{
    public class AddGenreMappings : Profile
    {
        public AddGenreMappings()
        {
            CreateMap<AddGenreCommand, Genre>();
        }
    }
}

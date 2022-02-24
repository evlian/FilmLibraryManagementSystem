using AutoMapper;
using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Queries;

namespace FilmLibraryManagementSystem.Core.Framework.Mapping.Films.Queries.GetAllFilms
{
    public class GetAllFilmsMappings : Profile
    {
        public GetAllFilmsMappings()
        {
            CreateMap<Film, FilmModel>();
        }
    }
}

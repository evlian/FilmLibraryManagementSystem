using AutoMapper;
using Pixond.Model;
using Pixond.Model.General.Queries;

namespace Pixond.Core.Framework.Mapping.Films.Queries.GetAllFilms
{
    public class GetAllFilmsMappings : Profile
    {
        public GetAllFilmsMappings()
        {
            CreateMap<Film, FilmModel>();
        }
    }
}

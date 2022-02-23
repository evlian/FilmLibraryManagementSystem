using FilmLibraryManagementSystem.Core.Services.Films;
using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetAllFilms
{
    public class GetAllFilmsHandler : IRequestHandler<GetAllFilmsQuery, GetAllFilmsResult>
    {
        private readonly IFilmsService _filmsService;

        public GetAllFilmsHandler(IFilmsService service) 
        {
            _filmsService = service;
        }

        public async Task<GetAllFilmsResult> Handle(GetAllFilmsQuery request, CancellationToken cancellationToken)
        {
            GetAllFilmsResult result = new GetAllFilmsResult();
            var films = await _filmsService.GetAllFilms(cancellationToken);
            result.AllFilms = new List<FilmModel>();
            foreach (Film film in films) 
            {
                var f = new FilmModel();
                f.Id = film.FilmId;
                f.Title = film.Title;
                f.Director = film.Director;
                f.Description = film.Description;
                f.Length = film.Length.ToString();
                foreach (Genre genre in film.Genres)
                {
                    f.Genre.Add(genre.Name);
                }
                result.AllFilms.Add(f);
            }
            return result;
        }
    }
}

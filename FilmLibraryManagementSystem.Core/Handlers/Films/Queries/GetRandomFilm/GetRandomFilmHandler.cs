using FilmLibraryManagementSystem.Data;
using FilmLibraryManagementSystem.Model.General.Queries;
using MediatR;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using FilmLibraryManagementSystem.Core.Services.Films;

namespace FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetRandomFilm
{
    public class GetRandomFilmHandler : IRequestHandler<GetRandomFilmQuery, GetRandomFilmResult>
    {
        private readonly IFilmsService _filmsService;

        public GetRandomFilmHandler(IFilmsService filmsService)
        { 
            _filmsService = filmsService;
        }
        public async Task<GetRandomFilmResult> Handle(GetRandomFilmQuery request, CancellationToken cancellationToken)
        {
            return new GetRandomFilmResult() { Film = await _filmsService.GetRandomFilm(cancellationToken)};
        }
    }
}

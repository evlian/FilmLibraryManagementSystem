using FilmLibraryManagementSystem.Core.Services.Films;
using FilmLibraryManagementSystem.Data;
using FilmLibraryManagementSystem.Model.General.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetAllFilms
{
    public class GetFilmByIdHandler : IRequestHandler<GetFilmByIdQuery, GetFilmByIdResult>
    {
        private readonly IFilmsService _filmsService;

        public GetFilmByIdHandler(IFilmsService service)
        {
            _filmsService = service;
        }

        public async Task<GetFilmByIdResult> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            return new GetFilmByIdResult { Film = await _filmsService.GetFilmById(request.Id, cancellationToken) };
        }
    }
}

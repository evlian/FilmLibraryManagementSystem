using AutoMapper;
using Pixond.Core.Services.Films;
using Pixond.Data;
using Pixond.Model.General.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Pixond.Core.Handlers.Films.Queries.GetAllFilms
{
    public class GetFilmByIdHandler : IRequestHandler<GetFilmByIdQuery, GetFilmByIdResult>
    {
        private readonly IFilmsService _filmsService;
        private readonly IMapper _mapper;

        public GetFilmByIdHandler(IFilmsService service, IMapper mapper)
        {
            _filmsService = service;
            _mapper = mapper;
        }

        public async Task<GetFilmByIdResult> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            return new GetFilmByIdResult
            {
                Film = _mapper.Map<FilmModel>(await _filmsService.GetFilmById(request.Id, cancellationToken))
            };
        }
    }
}

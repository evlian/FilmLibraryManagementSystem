using AutoMapper;
using FilmLibraryManagementSystem.Core.Services.Films;
using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Commands.Films;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Handlers.Films.Commands.EditFilm
{
    public class EditFilmCommandHandler : IRequestHandler<EditFilmCommand, EditFilmResponse>
    {
        private readonly IFilmsService _service;
        private readonly IMapper _mapper;

        public EditFilmCommandHandler(IFilmsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<EditFilmResponse> Handle(EditFilmCommand request, CancellationToken cancellationToken)
        {
            var film = _mapper.Map<Film>(request.Film);
            int id = request.Id;
            await _service.EditFilm(film, id, cancellationToken);
            return new EditFilmResponse();
        }
    }
}

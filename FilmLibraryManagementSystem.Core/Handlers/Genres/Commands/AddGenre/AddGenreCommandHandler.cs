using AutoMapper;
using FilmLibraryManagementSystem.Core.Abstraction.Services.Genres;
using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Commands.Genres;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Handlers.Genres.Commands.AddGenre
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, AddGenreResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenresService _service; 

        public AddGenreCommandHandler(IMapper mapper, IGenresService service)
        { 
            _mapper = mapper;
            _service = service;
        }
        public async Task<AddGenreResponse> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<Genre>(request);
            await _service.AddGenre(genre, cancellationToken);
            return new AddGenreResponse(); 
        }
    }
}

using FilmLibraryManagementSystem.Model.General.Commands.Genres;
using FilmLibraryManagementSystem.Model.General.Queries.Genres;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.App.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : BaseController
    {
        private readonly ILogger<GenreController> _logger;

        public GenreController(ILogger<GenreController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<GetAllGenresResult> GetAllGenres()
        {
            return await Mediator.Send(new GetAllGenresQuery());
        }

        [HttpPost("add")]
        public async Task<AddGenreResponse> AddGenre([FromBody] AddGenreCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}


using Pixond.App.Controllers;
using Pixond.Core.Extensions.Validation;
using Pixond.Core.Framework.Validation.Films.Queries;
using Pixond.Data;
using Pixond.Model;
using Pixond.Model.General.Commands;
using Pixond.Model.General.Commands.Films;
using Pixond.Model.General.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Pixond.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmController : BaseController
    {
        private readonly ILogger<FilmController> _logger;

        public FilmController(ILogger<FilmController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<GetAllFilmsResult> GetAllFilms()
        {
            return await Mediator.Send(new GetAllFilmsQuery());
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<GetFilmByIdResult>> GetFilmById([FromRoute]int id) 
        {
            var query = new GetFilmByIdQuery() { Id = id };
            var validator = new GetFilmByIdValidation().Validate(query);
            if (!validator.IsValid) 
            {
                return BadRequest(validator.Errors);
            }
            return await Mediator.Send(query);
        }

        [HttpPost("add")]
        public async Task<ActionResult<AddFilmResponse>> AddFilm([FromBody] AddFilmCommand command)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            return await Mediator.Send(command);
        }


        [HttpGet("random")]
        public async Task<GetRandomFilmResult> GetRandom()
        {
            return await Mediator.Send(new GetRandomFilmQuery());
        }

        [HttpGet("{title}")]
        public async Task<GetFilmsByTitleResult> GetFilmByTitle(string title)
        {
            return await Mediator.Send(new GetFilmsByTitleQuery() { Title = title});
        }

        [HttpPut]
        public async Task<IActionResult> EditFilm([FromBody]EditFilmCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}

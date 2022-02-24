
using FilmLibraryManagementSystem.App.Controllers;
using FilmLibraryManagementSystem.Core.Extensions.Validation;
using FilmLibraryManagementSystem.Core.Framework.Validation.Films.Queries;
using FilmLibraryManagementSystem.Data;
using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Commands;
using FilmLibraryManagementSystem.Model.General.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Controllers
{
    [Route("api/films")]
    [ApiController]
    public class FilmController : BaseController
    {
        private readonly ILogger<FilmController> _logger;
        private readonly static FilmLibraryContext _context = new FilmLibraryContext();

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

        [HttpPut("{id:int}")]
        public IActionResult EditFilm(int id, [FromBody]Film film)
        {
            if ((id <= 0 && id > _context.Films.Count()) || film == null)
                return BadRequest();
            film.FilmId = id;
            var oldFilm = _context.Films.Where(film => film.FilmId == id).SingleOrDefault();
            oldFilm.Title = film.Title;
            oldFilm.Description = film.Description;
            oldFilm.Director = film.Director;
            oldFilm.ReleaseDate = film.ReleaseDate;
            _context.Entry(oldFilm).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(_context.Films.Find(id));
        }
    }
}

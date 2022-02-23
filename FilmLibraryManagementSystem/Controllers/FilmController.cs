
using FilmLibraryManagementSystem.App.Controllers;
using FilmLibraryManagementSystem.Data;
using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Commands;
using FilmLibraryManagementSystem.Model.General.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        public async Task<GetFilmByIdResult> GetFilmById(int id) 
        {
            GetFilmByIdQuery query = new GetFilmByIdQuery();
            query.Id = id;
            return await Mediator.Send(query);
        }

        [HttpPost("add")]
        public async Task<AddFilmResponse> AddFilm([FromBody] Film film)
        {
            var command = new AddFilmCommand();
            command.Film = film;
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

using FilmLibraryManagementSystem.Controllers;
using FilmLibraryManagementSystem.Data;
using FilmLibraryManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace FilmLibraryManagementSystem.App.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ILogger<GenreController> _logger;
        private readonly static FilmLibraryContext _context = new FilmLibraryContext();

        public GenreController(ILogger<GenreController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        [HttpPost("add")]
        public IActionResult AddGenre([FromBody]Genre genre)
        {
            if (genre.Name == string.Empty)
                return BadRequest("Please enter a name for your genre!");
            var genreExists = from g in _context.Films
                        where g.Title == genre.Name
                        select true;
            if (genreExists.FirstOrDefault().Equals(true))
                return BadRequest("A genre with that name already exists!");
            _context.Add(new Genre { Name = genre.Name});
            _context.SaveChanges();
            return Ok("Action completed successfully!");
        }
    }
}

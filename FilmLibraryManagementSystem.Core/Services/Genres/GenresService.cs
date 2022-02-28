using FilmLibraryManagementSystem.Core.Abstraction.Services.Genres;
using FilmLibraryManagementSystem.Core.Services.Films;
using FilmLibraryManagementSystem.Data;
using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Commands.Genres;
using FilmLibraryManagementSystem.Model.General.Queries.Genres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Services.Genres
{
    public class GenresService : IGenresService
    {
        private readonly ILogger<GenresService> _logger;
        private readonly FilmLibraryContext _context;

        public GenresService(FilmLibraryContext context, ILogger<GenresService> logger)
        { 
            _context = context;
            _logger = logger;
        }

        public async Task<Genre> AddGenre(Genre genre, CancellationToken cancellationToken)
        {
            await _context.Genres.AddAsync(genre, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return genre;
        }

        public async Task<List<Genre>> GetAllGenres(GetAllGenresQuery query, CancellationToken cancellationToken)
        {
            return await _context.Genres.ToListAsync(cancellationToken);
        }
    }
}

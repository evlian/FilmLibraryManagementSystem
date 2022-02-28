using FilmLibraryManagementSystem.Model.General.Queries.Genres;
using FilmLibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmLibraryManagementSystem.Model.General.Commands.Genres;

namespace FilmLibraryManagementSystem.Core.Abstraction.Services.Genres
{
    public interface IGenresService
    {
        Task<List<Genre>> GetAllGenres(GetAllGenresQuery query, CancellationToken cancellationToken);
        Task<Genre> AddGenre(Genre genre, CancellationToken cancellationToken);
    }
}

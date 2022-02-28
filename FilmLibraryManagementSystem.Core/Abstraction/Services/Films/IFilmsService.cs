using FilmLibraryManagementSystem.Model;
using FilmLibraryManagementSystem.Model.General.Commands;
using FilmLibraryManagementSystem.Model.General.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Services.Films
{
    public interface IFilmsService
    {
        public Task<List<Film>> GetAllFilms(CancellationToken cancellationToken);
        public Task<Film> GetFilmById(int id, CancellationToken cancellationToken);
        public Task<List<Film>> GetFilmsByTitle(string title, CancellationToken cancellationToken);
        public Task<Film> GetRandomFilm(CancellationToken cancellationToken);
        public Task<Film> AddFilm(AddFilmCommand film, CancellationToken cancellation);
        public Task<Film> EditFilm(Film film, int id, CancellationToken cancellationToken);
        
    }
}

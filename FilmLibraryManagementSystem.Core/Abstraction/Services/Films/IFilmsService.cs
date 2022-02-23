using FilmLibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Task<Film> AddFilm(Film film, CancellationToken cancellation);
        
    }
}

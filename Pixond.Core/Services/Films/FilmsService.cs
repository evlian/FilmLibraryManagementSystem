﻿using Pixond.Data;
using Pixond.Model;
using Pixond.Model.General.Commands;
using Pixond.Model.General.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pixond.Core.Services.Films
{
    public class FilmsService : IFilmsService
    {
        private readonly ILogger<FilmsService> _logger;
        private readonly FilmLibraryContext _context;

        public FilmsService(ILogger<FilmsService> logger, FilmLibraryContext context)
        { 
            _logger = logger;
            _context = context;
        }

        public async Task<Film> AddFilm(AddFilmCommand command, CancellationToken cancellation)
        {
            Film film = new() { Description = command.Description, Director = command.Director, Title = command.Title, Length = command.Length , ReleaseDate = command.ReleaseDate};
            _context.Add(film);
            await _context.SaveChangesAsync();
            var filmContext = _context.Films.Include(x => x.Genres)
                            .Include(x => x.Genres)
                            .Single(x => x.Title == film.Title);
            foreach (string genre in command.FilmGenres)
            {
                var existing = await _context.Genres.SingleOrDefaultAsync(g => g.Name.Equals(genre));
                filmContext.Genres.Add(existing);
            }
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<Film> EditFilm(Film film, int id, CancellationToken cancellationToken)
        {
            film.FilmId = id;
            var oldFilm = _context.Films.Where(film => film.FilmId == id).SingleOrDefault();
            if (film.Title != null)
                oldFilm.Title = film.Title;
            if (film.Description != null)
                oldFilm.Description = film.Description;
            if (film.Director != null)
                oldFilm.Director = film.Director;
            if (film.ReleaseDate != DateTime.MinValue)
                oldFilm.ReleaseDate = film.ReleaseDate;
            _context.Entry(oldFilm).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return film;
        }

        public async Task<List<Film>> GetAllFilms(CancellationToken cancellationToken)
        {
            return await _context.Films.Include(x => x.Genres).ToListAsync(cancellationToken);
        }

        public async Task<Film> GetFilmById(int id, CancellationToken cancellationToken)
{
            return await _context.Films.FindAsync(id);
        }

        public Task<List<Film>> GetFilmsByTitle(string title, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Film> GetRandomFilm(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
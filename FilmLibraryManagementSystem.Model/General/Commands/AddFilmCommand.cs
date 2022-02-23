using MediatR;
using System;
using System.Collections.Generic;

namespace FilmLibraryManagementSystem.Model.General.Commands
{
    public class AddFilmCommand : IRequest<AddFilmResponse>
    {
        public string FilmTitle { get; set; }
        public string FilmDirector { get; set; }
        public string FilmDescription { get; set; }
        public int Length { get; set; }
        public DateTime FilmReleaseDate { get; set; }
        public ICollection<string> FilmGenres { get; set; }
    }
}

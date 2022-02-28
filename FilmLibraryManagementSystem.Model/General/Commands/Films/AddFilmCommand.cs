using MediatR;
using System;
using System.Collections.Generic;

namespace FilmLibraryManagementSystem.Model.General.Commands
{
    public class AddFilmCommand : IRequest<AddFilmResponse>
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<string> FilmGenres { get; set; }
    }
}

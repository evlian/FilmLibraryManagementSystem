using System;
using System.Collections.Generic;

namespace FilmLibraryManagementSystem.Model
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        public ICollection<Genre> Genres { get; set; }

    }
}

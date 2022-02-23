using System.Collections.Generic;

namespace FilmLibraryManagementSystem.Model
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}

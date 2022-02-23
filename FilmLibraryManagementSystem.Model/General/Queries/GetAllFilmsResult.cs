using System;
using System.Collections.Generic;

namespace FilmLibraryManagementSystem.Model.General.Queries
{
    public class GetAllFilmsResult
    {
        public List<FilmModel> AllFilms { get; set; } = new List<FilmModel>();
    }

    public class FilmModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public string Director  { get; set; }
        public List<string> Genre { get; set; } = new List<string>();
    }
}

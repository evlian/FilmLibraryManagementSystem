﻿using Pixond.Model.Entities;
using System;

namespace Pixond.Model
{
    public class FilmGenre
    {
        public int FilmId { get; set; }
        public int GenreId { get; set;}

        public Film Film { get; set; }
        public Genre Genre { get; set; }
    }
}

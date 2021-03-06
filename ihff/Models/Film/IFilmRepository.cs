﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihff.Models
{
    interface IFilmRepository
    {
        IEnumerable<Film> GetAllFilms();
        IEnumerable<FilmModel> GetDayFilms();
        IEnumerable<Film> GetTopFilms();
        FilmInformationModel GetFilmInformation(int filmId);
    }
}

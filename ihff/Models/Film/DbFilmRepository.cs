using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbFilmRepository : IFilmRepository
    {
        private IhffContext ihff = new IhffContext();
        public IEnumerable<Film> ShowAllfilms()
        {
            IEnumerable<Film> allFilms = ihff.FILMS;
            return allFilms;
            
        }
    }
}
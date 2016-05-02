using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbFilmRepository : IFilmRepository
    {
        private IhffContext ihff = new IhffContext();
        public IEnumerable<Film> GetAllfilms()
        {
            IEnumerable<Film> allFilms = (IEnumerable<Film>)(from f in ihff.FILMS
                         join e in ihff.EVENTS
                             on f.Film_Id equals e.Film_Id
                         join l in ihff.LOCATIONS
                             on e.Location_Id equals l.Location_Id
                         select new { f.Film_Id, f.Name, f.ShortDescription, e.Day, e.Time, Location = l.Name });

            return allFilms;

        }
    }
}
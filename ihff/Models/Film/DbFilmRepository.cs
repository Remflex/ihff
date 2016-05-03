using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbFilmRepository : IFilmRepository
    {
        private IhffContext ihff = new IhffContext();

        // gets all films 
        public IEnumerable<Film> GetAllFilms()
        {
            IEnumerable<Film> allFilms = ihff.FILMS;

            return allFilms;
        }

        //gets all films and the information needed
        public IEnumerable<FilmModel> GetDayFilms()
        {
            IEnumerable<FilmModel> allFilms = (IEnumerable<FilmModel>)
                (from f in ihff.FILMS
                 join e in ihff.EVENTS
                 on f.Film_Id equals e.Film_Id
                 join l in ihff.LOCATIONS
                 on e.Location_Id equals l.Location_Id
                 select new FilmModel
                 {
                     Film_Id = f.Film_Id,
                     Name = f.Name,
                     ShortDescription = f.ShortDescription,
                     Day = e.Day,
                     Time = e.Time,
                     Location = l.Name
                 });

            return allFilms;
        }

        //Get the top 10 films
        public IEnumerable<Film> GetTopFilms()
        {
            IEnumerable<Film> topFilms = ihff.FILMS.OrderByDescending(f => f.Rating);

            return topFilms;
        }

        // Get all the information of one film
        public FilmInformationModel GetFilmInformation(int filmId)
        {
            //IEnumerable<Film> film = (IEnumerable<Film>)
            //    (from f in ihff.FILMS
            //     where filmId == f.Film_Id
            //     select new Film
            //     {
            //         Film_Id = f.Film_Id,
            //         Name = f.Name,
            //         ShortDescription = f.ShortDescription,
            //         FullDescription = f.FullDescription,
            //         Runtime = f.Runtime,
            //         Genre = f.Genre,
            //         Year = f.Year,
            //         Cast = f.Cast,
            //         Director = f.Director,
            //         Language = f.Language,
            //         Age = f.Age,
            //         Rating = f.Rating,
            //         Hyperlink = f.Hyperlink
            //     });

            IEnumerable<Film> film = ihff.FILMS.Where(f => f.Film_Id == filmId);

            IEnumerable<DayTimeLocationModel> dTL = (IEnumerable<DayTimeLocationModel>)
            (from f in ihff.FILMS
             where filmId == f.Film_Id
             join e in ihff.EVENTS
             on f.Film_Id equals e.Film_Id
             join l in ihff.LOCATIONS
             on e.Location_Id equals l.Location_Id
             
             select new DayTimeLocationModel
             {
                 Day = e.Day,
                 Time = e.Time,
                 Location = l.Name
             });
            List<Film> Film = film.ToList();
            List<DayTimeLocationModel> DTL = dTL.ToList();

            FilmInformationModel filmInformation = new FilmInformationModel(Film, DTL);

            return filmInformation;
        }
    }
}
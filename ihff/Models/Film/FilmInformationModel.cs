using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class FilmInformationModel
    {
        public List<Film> Film { get; set;  }
        public List<DayTimeLocationModel> DTL { get; set; }

        public FilmInformationModel()
        {

        }
        public FilmInformationModel(List<Film> film, List<DayTimeLocationModel> DTL)
        {
            this.Film = film;
            this.DTL = DTL;
        }
    }
}
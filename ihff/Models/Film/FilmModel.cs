using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class FilmModel
    {
        public int Film_Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int Rating { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }

        public FilmModel()
        {

        }

        public FilmModel(int id, string name, string shortDes, string day, string time, string location)
        {
            Film_Id = id;
            this.Name = name;
            this.ShortDescription = shortDes;
            this.Day = day;
            this.Time = time;
            this.Location = location;
        }
    }
}
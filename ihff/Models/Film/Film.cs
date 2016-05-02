using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("FILMS")]

    public class Film
    {
        // Properties
        [Required]
        [Key]
        public int Film_Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int Runtime { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public string Age { get; set; }
        public int Rating { get; set; }
        public string Hyperlink { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }

        // Constructor
        public Film()
        {

        }
        public Film(int id, string name, string shortDes, string longDes, int run, string genre, int year, string cast, string director, string lang, string age, int rating, string link)
        {
            this.Film_Id = id;
            this.Name = name;
            this.ShortDescription = shortDes;
            this.FullDescription = longDes;
            this.Runtime = run;
            this.Genre = genre;
            this.Year = year;
            this.Cast = cast;
            this.Director = director;
            this.Language = lang;
            this.Age = age;
            this.Rating = rating;
            this.Hyperlink = link;
        }
        public Film(int id, string name, string shortDes, string day, string time, string locaction)
        {
            Film_Id = id;
            this.Name = name;
            this.ShortDescription = shortDes;
            this.Day = day;
            this.Time = time;
            this.Location = Location;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class Film
    {
        // Properties
        [Required][Key]
        public int Film_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Short_Description { get; set; }
        public string Full_Description { get; set; }
        [Required]
        public int Runtime { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Cast { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Language { get; set; }
        public string Age { get; set; }
        public float Rating { get; set; }
        public string Hyperlink { get; set; }
        // Constructor
        public Film(int id, string name,string shortDes, string longDes, int run, string genre, int year, string cast, string director, string lang, string age, float rating, string link)
        {
            Film_Id = id;
            this.Name = name;
            Short_Description = shortDes;
            Full_Description = longDes;
            Runtime = run;
            this.Genre = genre;
            this.Year = year;
            this.Cast = cast;
            this.Director = director;
            Language = lang;
            this.Age = age;
            this.Rating = rating;
            Hyperlink = link;
        }       
        }
}
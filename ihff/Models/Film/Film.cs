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
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        public float Rating { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int Runtime { get; set; }
        public string Age { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Cast { get; set; }
        public string Hyperlink { get; set; }

        // Constructor
        public Film() { }
        
        }
}
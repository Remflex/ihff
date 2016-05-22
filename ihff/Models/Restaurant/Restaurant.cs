using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("RESTAURANTS")]
    public class Restaurant
    {
        [Required]
        [Key]
        public int Restaurant_Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Kitchen { get; set; }
        public string LunchHours { get; set; }
        public string DinnerHours { get; set; }
        public int Location_Id { get; set; }
        public int Rating { get; set; }
        public string Hyperlink { get; set; }

        public Restaurant()
        {
        }

        public Restaurant(int id, string name, string shortdes, string full, string kitchen, string lunch, string diner,int loc, int rating, string hyper )
        {
            Restaurant_Id = id;
            this.Name = name;
            ShortDescription = shortdes;
            FullDescription = full;
            Kitchen = kitchen;
            LunchHours = lunch;
            DinnerHours = diner;
            Location_Id = loc;
            this.Rating = rating;
            Hyperlink = hyper;
        }
    }
}
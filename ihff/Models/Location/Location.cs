using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("LOCATIONS")]
    public class Location
    {
        [Required]
        [Key]
        public int Location_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public string Seats { get; set; }

        public Location()
        {
               
        }

        public Location(int id, string name, string address, string zip, string city, int cap, string seats)
        {
            Location_Id = id;
            this.Name = name;
            this.Address = address;
            Postcode = zip;
            this.City = city;
            Capacity = cap;
            this.Seats = seats;
        }
    }
}
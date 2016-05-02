using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{

        [Table("EVENTS")]

    public class Event
    {
        [Required]
        [Key]
        public int Event_Id { get; set; }

        public int Film_Id { get; set; }

        public int Special_Id { get; set; }

        public string Day { get; set; }

        public string Time { get; set; }

        [Required]
        public int Location_Id { get; set; }

        public Event()
        {

        }

        public Event(int id, int film, int special, string day, string time, int location)
        {
            Event_Id = id;
            Film_Id = film;
            Special_Id = special;
            this.Day = day;
            this.Time = time;
            Location_Id = location;
        }
    
    }
}
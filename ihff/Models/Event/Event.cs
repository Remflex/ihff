using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class Event
    {
        [Key]
        public int Event_Id { get; set; }

        public string Name { get; set; }

        public string Day { get; set; }

        public string Time { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public string Type { get; set; }

        public Event()
        {

        }

        public Event(int id, string name, string day, string time, string location, int capacity, string type)
        {
            Event_Id = id;
            this.Name = name;
            this.Day = day;
            this.Time = time;
            this.Location = location;
            this.Capacity = capacity;
            this.Type = type;
        }
    
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DayTimeLocationModel
    {
        public string Day { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }

        public DayTimeLocationModel()
        {

        }

        public DayTimeLocationModel(string day, string time, string location)
        {
            this.Day = day;
            this.Time = time;
            this.Location = location;
        }
    }
}
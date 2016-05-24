using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class SpecialModel
    {
        public int Special_Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Salutation { get; set; }
        public string Led_By { get; set; }
        public string ExtraInfo { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }

        public SpecialModel()
        {

        }

        public SpecialModel(int id, string name, string shortDes, string sal, string led, string extra, string day, string time, string location)
        {
            Special_Id = id;
            this.Name = name;
            this.ShortDescription = shortDes;
            Salutation = sal;
            Led_By = led;
            ExtraInfo = extra;
            this.Day = day;
            this.Time = time;
            this.Location = location;
        }
    }
}
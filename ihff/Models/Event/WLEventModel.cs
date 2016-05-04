using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class WLEventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Soort { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public WLEventModel(int Id, string Name, string Soort, string Day, string Time, int Quantity, float Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Soort = Soort;
            this.Day = Day;
            this.Time = Time;
            this.Quantity = Quantity;
            this.Price = Price;
        }
    }
}
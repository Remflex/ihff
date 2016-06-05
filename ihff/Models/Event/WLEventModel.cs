using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class WLEventModel
    {
        [Required]
        [Display(Name= "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Type { get; set; }

        [Display(Name = "Showing")]
        public int Showing { get; set; }

        [Display(Name = "DayTimeLocation")]
        public DayTimeLocationModel DayTimeLocation { get; set; }

        [Display(Name = "Day")]
        public string Day { get; set; }

        [Display(Name = "Time")]
        public string Time { get; set; }

        [Display(Name = "Address")]
        public RestaurantAddressModel Address { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        public float Price { get; set; }


        public WLEventModel()
        {

        }

        public WLEventModel(int id, string name,string type, DayTimeLocationModel dtl, int quantity, float price)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            DayTimeLocation = dtl;
            this.Quantity = quantity;
            this.Price = price;
        }

        public WLEventModel(int id, string name,string type, string day,string time, RestaurantAddressModel address, int quantity, float price)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Day = day;
            this.Time = time;
            this.Address = address;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
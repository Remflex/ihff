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
    }
}
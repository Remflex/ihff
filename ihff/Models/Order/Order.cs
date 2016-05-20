using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    public class Order
    {
        [Required]
        [Display(Name = "Payment")]
        public string PaymentMethod { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "TotalPrice")]
        public float TotalPrice { get; set; }

        public Order()
        {

        }

        public Order(string payment, string name, string email, float total)
        {
            PaymentMethod = payment;
            this.Name = name;
            this.Email = email;
            TotalPrice = total;
        }
    }
}
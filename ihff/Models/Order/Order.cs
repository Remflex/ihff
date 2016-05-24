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
        [Key]
        public int Order_Id { get; set; }

        [Required]
        [Display(Name = "TotalPrice")]
        public float TotalPrice { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Code { get; set; }
        public string Type { get; set; }

        [Required]
        [Display(Name = "Payment")]
        public string PaymentMethod { get; set; }

        public Order()
        {

        }

        public Order(string payment, string name, string email, float total)
        {
            PaymentMethod = payment;
            this.Name = name;
            this.Email = email;
            TotalPrice = total;
            Code = GetCode();
        }

        public string GetCode()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new String(stringChars);

            return finalString;
        }
    }
}
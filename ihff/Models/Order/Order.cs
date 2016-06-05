using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table ("ORDER")]
    public class Order
    {
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Order_Id { get; set; }

        [Required]
        [Display(Name = "TotalPrice")]
        public double TotalPrice { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }
        
        public string OrderType { get; set; }

        [Display(Name = "Payment")]
        public string PaymentMethod { get; set; }

        public Order()
        {

        }

        public Order(string payment, string name, string email, double total)
        {
            PaymentMethod = payment;
            this.Name = name;
            this.Email = email;
            TotalPrice = total;
            Code = CodeGenerator.GenerateCode();
        }

        public Order(string payment, string name, string email, double total, int orderId, float price, string code)
        {
            PaymentMethod = payment;
            this.Name = name;
            this.Email = email;
            TotalPrice = total;
            Order_Id = orderId;
            TotalPrice = price;
            this.Code = code;
        }
    }
}
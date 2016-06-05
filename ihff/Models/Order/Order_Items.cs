using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("ORDER_ITEMS")]

    public class Order_Items
    {
        [Required]
        [Key]
        public int Item_Id { get; set; }

        [Required]
        public int Order_Id { get; set; }

        public int Event_Id { get; set; }

        public int Restaurant_Id { get; set; }

        public string TicketType { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public string Time { get; set; }

        public Order_Items()
        {

        }

        public Order_Items(int eId, int rId,string ticket, int amount, string day, string time)
        {
            Event_Id = eId;
            Restaurant_Id = rId;
            TicketType = ticket;
            this.Amount = amount;
            this.Day = day;
            this.Time = time;
        }
    }
}
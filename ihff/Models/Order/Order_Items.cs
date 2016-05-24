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
        public int Order_Id { get; set; }

        [Required]
        public int Ticket_Id { get; set; }

        [Required]
        public int Ammount { get; set; }

    }
}
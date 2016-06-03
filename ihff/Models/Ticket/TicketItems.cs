using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ihff.Models

{
    [Table("TICKET_ITEMS")]
    public class TicketItems
    {
        //Properties
        [Required]
        [Key]
        public int Id { get; set; }
        public int Event_Id { get; set; }
        public int Reservation_Id { get; set; }
        public int Amount { get; set; }

        //constructor
        public TicketItems()
        {
        }

        public TicketItems(int id, int eid, int rid, int amount)
        {
            this.Id = id;
            this.Event_Id = eid;
            this.Reservation_Id = rid;
            this.Amount = amount;
        }
    }
}
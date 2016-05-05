using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("TICKETS")]
    public class Ticket
    {
        //Properties
        [Required]
        [Key]
        public int Id { get; set; }
        public int Event_Id { get; set; }
        public int Reservation_Id { get; set; }
        public string Tickettype { get; set; }

        //constructor
        public Ticket()
        {
        }

        public Ticket(int id, int eid, int rid, string type)
        {
            this.Id = id;
            this.Event_Id = eid;
            this.Reservation_Id = rid;
            this.Tickettype = type;
        }
    }
}
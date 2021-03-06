﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("TICKET")]
    public class Ticket
    {
        //Properties
        [Required]
        [Key]
        public int Id { get; set; }
        public string Tickettype { get; set; }

        //constructor
        public Ticket()
        {
        }

        public Ticket(int id, string type)
        {
            this.Id = id;
            this.Tickettype = type;
        }
    }
}
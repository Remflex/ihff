﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ihff.Models
{
    public class IhffContext : DbContext
    {
        public IhffContext()
            : base("IHFFConnection") { }

      //  public DbSet<Event> EVENTS { get; set; }
        public DbSet<Film> FILMS { get; set; }

    }
}
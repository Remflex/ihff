using System;
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

        public DbSet<Film> FILMS { get; set; }
        public DbSet<Event> EVENTS { get; set; }
        public DbSet<Location> LOCATIONS { get; set; }
        public DbSet<Restaurant> RESTAURANTS { get; set; }
        public DbSet<Special> SPECIALS { get; set; }
        public DbSet<Sight> SIGHTS { get; set; }
        public DbSet<Order> ORDER { get; set; }
        public DbSet<Order_Items> ORDER_ITEMS { get; set; }
        public DbSet<Ticket> TICKETS { get; set; }
    }
}
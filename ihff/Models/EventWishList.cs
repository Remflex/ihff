using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class EventWishList
    {
        public List<WLEventModel> Events{ get; set; }

        public EventWishList(List<WLEventModel> events)
        {
            this.Events = events;
        }
    }
}
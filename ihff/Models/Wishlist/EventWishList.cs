using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class EventWishList
    {
        [Required]
        [Display(Name = "Events")]
        public List<WLEventModel> Events{ get; set; }

        public EventWishList()
        {

        }

        public EventWishList(List<WLEventModel> events)
        {
            this.Events = events;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("WISHLISTS")]

    public class Wishlist
    {
        // Properties
        [Required]
        [Key]
        public int Wishlist_Id { get; set; }
        public string ManagementCode { get; set; }
        public string ShareCode { get; set; }

        // Constructor
        public Wishlist()
        {
        }

        public Wishlist(int id, string mcode, string scode)
        {
            this.Wishlist_Id = id;
            this.ManagementCode = mcode;
            this.ShareCode = scode;
        }
    }
}
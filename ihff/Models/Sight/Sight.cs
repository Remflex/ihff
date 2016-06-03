using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("SIGHTS")]
    public class Sight
    {
        //Properties
        [Required]
        [Key]
        public int Sight_Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Hyperlink { get; set; }

        //Constructor
        public Sight()
        {
        }

        public Sight(int id, string name, string shortd, string link)
        {
            this.Sight_Id = id;
            this.Name = name;
            this.ShortDescription = shortd;
            this.Hyperlink = link;
        }
    }
}
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int Location_Id { get; set; }
        public string Hyperlink { get; set; }

        //Constructor
        public Sight()
        {
        }

        public Sight(int id, string name, string shortd, string fulld, int location, string link)
        {
            this.Id = id;
            this.Name = name;
            this.ShortDescription = shortd;
            this.FullDescription = fulld;
            this.Location_Id = location;
            this.Hyperlink = link;
        }
    }
}
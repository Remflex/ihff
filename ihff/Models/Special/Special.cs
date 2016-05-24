using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    [Table("SPECIALS")]
    public class Special
    {
        // Properties
        [Required]
        [Key]
        public int Special_Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Salutation { get; set; }

        [Required]
        public string Led_By { get; set; }
        public string ExtraInfo { get; set; }

        // Constructor
        public Special() { }

        public Special(int id, string name, string shortDes, string fullDes, string sal, string led, string extra)
        {
            Special_Id = id;
            this.Name = name;
            ShortDescription = shortDes;
            FullDescription = fullDes;
            Salutation = sal;
            Led_By = led;
            this.ExtraInfo = extra;
        }
    }
}
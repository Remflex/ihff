using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class Special
    {
        // Properties
        [Required][Key]
        public int Special_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Short_Description { get; set; }
        public string Full_Description { get; set; }
        [Required]
        public string Led_By { get; set; }
        public string Extra { get; set; }

        // Constructor
        public Special() { }
    }
}
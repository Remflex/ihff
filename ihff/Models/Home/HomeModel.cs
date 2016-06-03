using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class HomeModel
    {
        [Required]
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public HomeModel()
        {
        }

        public HomeModel(int id, string type, string name, string shortDescription)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.ShortDescription = shortDescription;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class RestaurantAddressModel
    {
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }

        public RestaurantAddressModel()
        {

        }

        public RestaurantAddressModel(string add, string post, string stad)
        {
            Address = add;
            Postcode = post;
            City = stad;
        }
    }
}
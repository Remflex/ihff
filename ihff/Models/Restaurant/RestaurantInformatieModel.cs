using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class RestaurantInformatieModel
    {
        public List<Restaurant> Restaurant { get; set; }
        public List<RestaurantAddressModel> Address{ get; set; }

        public RestaurantInformatieModel()
        {

        }

        public RestaurantInformatieModel(List<Restaurant> res, List<RestaurantAddressModel> add)
        {
            Restaurant = res;
            Address = add;
        }
    }
}
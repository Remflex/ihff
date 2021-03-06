﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihff.Models
{
    interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        RestaurantInformatieModel GetRestaurantInformation(int resId);
    }
}

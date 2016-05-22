using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbRestaurantRepository : IRestaurantRepository
    {
        private IhffContext ihff = new IhffContext();

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            IEnumerable<Restaurant> allRestaurants = ihff.RESTAURANTS;

            return allRestaurants;
        }

        public RestaurantInformatieModel GetRestaurantInformation(int resId)
        {

            IEnumerable<Restaurant> res = ihff.RESTAURANTS.Where(r => r.Restaurant_Id == resId);

            IEnumerable<RestaurantAddressModel> resInfo = (IEnumerable<RestaurantAddressModel>)
                (from r in ihff.RESTAURANTS
                 where resId == r.Restaurant_Id
                 join l in ihff.LOCATIONS
                     on r.Location_Id equals l.Location_Id

                 select new RestaurantAddressModel
                 {
                    Address = l.Address,
                    Postcode = l.Postcode,
                    City = l.City
                 });

            List<Restaurant> Restaurant = res.ToList();
            List<RestaurantAddressModel> Address = resInfo.ToList();

            RestaurantInformatieModel restaurantInfo = new RestaurantInformatieModel(Restaurant, Address);

            return restaurantInfo;
        }
    }
}
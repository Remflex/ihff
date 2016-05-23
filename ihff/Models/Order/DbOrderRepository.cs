using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbOrderRepository : IOrderRepository
    {
        private IhffContext ihff = new IhffContext();
        public void OrderToDatabase(List<WLEventModel> wishlist, Order information)
        {
            ihff.ORDER.Add(information);
            ihff.SaveChanges();

            foreach(WLEventModel wl in wishlist)
            {
                ihff.ORDER_ITEMS.Add(wl);
                ihff.SaveChanges();
            }      

        }
    }
}
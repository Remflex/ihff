using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihff.Models
{
    interface IOrderRepository
    {
        void OrderToDatabase(List<WLEventModel> wishlist, Order information, out string codeergeval);
        List<WLEventModel> GetWishlist(Order order);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbOrderRepository : IOrderRepository
    {
        private IhffContext ihff = new IhffContext();

        private int orderId;

        public void OrderToDatabase(List<WLEventModel> wishlist, Order information, out string codeergeval)
        {
            string type, day;
            bool dag = false, programma = true;
            int jadenk = 0;
            List<Order_Items> items = new List<Order_Items>();

            //Krijg alle codes uit de database
            IEnumerable<Order> coderingen = ihff.ORDER;

            List<Order> codes = coderingen.ToList();

            //Maak een nieuwe code en kijk of deze niet al in de database staat
            information.Code = CodeGenerator.GenerateCode();
            foreach (Order code in codes)
            {
                while (information.Code == code.Code)
                {
                    information.Code = CodeGenerator.GenerateCode();
                }
            }
            codeergeval = information.Code;

            //Geef het type en de dag van het eerste event aan
            type = wishlist[0].Type;
            if (type == "Film")
            {
                day = wishlist[0].DayTimeLocation.Day;
            }
            else
            {
                day = wishlist[0].Day;
            }

            //Kijk of de wishlist een filmticket is. Zo ja, Geef dit dat ook een filmticket
            //Als het iets anders is dan film en er staat maar één event in de wishlist maak er een item van
            if (wishlist.Count == 1 && type == "Film")
                items.Add(new Order_Items(wishlist[0].Id, 0, "FilmTicket", wishlist[0].Quantity, wishlist[0].DayTimeLocation.Day, wishlist[0].DayTimeLocation.Time));
            else if (wishlist.Count == 1 && type == "Restaurant")
                items.Add(new Order_Items(0, wishlist[0].Id, "", wishlist[0].Quantity, wishlist[0].Day, wishlist[0].Time));
            else if (wishlist.Count == 1 && type == "Special")
                items.Add(new Order_Items(wishlist[0].Id, 0, "", wishlist[0].Quantity, wishlist[0].Day, wishlist[0].Time));

            //Kijk of de wishlist een Food&Filmticket is. Zo ja, Geef dit dat ook een Food&Filmticket 
            if (wishlist.Count == 2)
            {
                if ((wishlist[1].Type == "Film" && type == "Restaurant" && wishlist[1].DayTimeLocation.Day == day) ||
                    (wishlist[1].Type == "Restaurant" && type == "Film" && wishlist[1].Day == day))
                {
                    if (wishlist[0].Type == "Film")
                        items.Add(new Order_Items(wishlist[0].Id, wishlist[1].Id, "Food&Film", wishlist[1].Quantity, wishlist[1].Day, wishlist[1].Time));
                    else
                        items.Add(new Order_Items(wishlist[1].Id, wishlist[0].Id, "Food&Film", wishlist[0].Quantity, wishlist[0].Day, wishlist[0].Time));
                }
                else
                { //Zet alle items op geen ticket
                    foreach (WLEventModel wl in wishlist)
                    {
                        if (wl.Type == "Restaurant")
                            items.Add(new Order_Items(0, wl.Id, "", wl.Quantity, wl.Day, wl.Time));
                        else if (wl.Type == "Film")
                            items.Add(new Order_Items(wl.Id, 0, "", wl.Quantity, wl.DayTimeLocation.Day, wl.DayTimeLocation.Time));
                        else if (wl.Type == "Special")
                            items.Add(new Order_Items(wl.Id, 0, "", wl.Quantity, wl.Day, wl.Time));
                    }
                }

            }

            //Kijk of de wishlist een Dagkaart is. Zo ja, Geef dit dat ook een Dagkaart
            if (wishlist.Count > 1)
            {
                while (dag && jadenk < wishlist.Count)
                {
                    for (int i = 0; i < wishlist.Count - 1; i++)
                    {
                        if (wishlist[i].Type == "Film" || wishlist[i].Type == "Special")
                            for (int j = 1; j < wishlist.Count; j++)
                            {
                                if (wishlist[i].Type == "Film" && wishlist[j].Type == "Film")
                                {
                                    if (wishlist[i].DayTimeLocation.Day == wishlist[j].DayTimeLocation.Day)
                                        dag = true;
                                }
                                else if (wishlist[i].Type == "Film" && wishlist[j].Type == "Special")
                                {
                                    if (wishlist[i].DayTimeLocation.Day == wishlist[j].Day)
                                        dag = true;
                                }
                                else if (wishlist[i].Type == "Special" && wishlist[j].Type == "Film")
                                {
                                    if (wishlist[i].Day == wishlist[j].DayTimeLocation.Day)
                                        dag = true;
                                }
                                else if (wishlist[i].Type == "Special" && wishlist[j].Type == "Special")
                                {
                                    if (wishlist[i].Day == wishlist[j].Day)
                                        dag = true;
                                }
                                else
                                    dag = false;
                            }
                        else
                            dag = false;
                    }
                    jadenk++;
                }
                if (dag)
                    foreach (Order_Items item in items)
                        item.TicketType = "Dagkaart";
            }

            //Kijk of de wishlist een programma is. Zo ja, Geef dit dat ook een programmaticket
            if (wishlist.Count > 1)
            {
                while (programma && jadenk < wishlist.Count())
                {
                    for (int i = 0; i < wishlist.Count - 1; i++)
                    {
                        if (wishlist[i].Type == "Film" || wishlist[i].Type == "Special")
                            for (int j = 1; j < wishlist.Count; j++)
                            {
                                if (wishlist[i].Type == "Film" && wishlist[j].Type == "Film")
                                {
                                    if (wishlist[i].DayTimeLocation.Day == wishlist[j].DayTimeLocation.Day)
                                        programma = true;
                                    else
                                        programma = false;
                                }
                                else if (wishlist[i].Type == "Film" && wishlist[j].Type == "Special")
                                {
                                    if (wishlist[i].DayTimeLocation.Day == wishlist[j].Day)
                                        programma = true;
                                    else
                                        programma = false;
                                }
                                else if (wishlist[i].Type == "Special" && wishlist[j].Type == "Film")
                                {
                                    if (wishlist[i].Day == wishlist[j].DayTimeLocation.Day)
                                        programma = true;
                                    else
                                        programma = false;
                                }
                                else if (wishlist[i].Type == "Special" && wishlist[j].Type == "Special")
                                {
                                    if (wishlist[i].Day == wishlist[j].Day)
                                        programma = true;
                                    else
                                        programma = false;
                                }
                            }
                        else
                            programma = true;
                    }
                    jadenk++;

                } if (!programma)
                    foreach (Order_Items item in items)
                        item.TicketType = "Programma";
            }


            ihff.ORDER.Add(information);
            ihff.SaveChanges();

            IEnumerable<Order> orderingen = ihff.ORDER.Where(o => o.Code == information.Code);
            List<Order> orders = orderingen.ToList();
            foreach (Order order in orders)
                orderId = order.Order_Id;

            foreach (Order_Items item in items)
            {
                item.Order_Id = orderId;
                ihff.ORDER_ITEMS.Add(item);
            }
            ihff.SaveChanges();
        }

        public List<WLEventModel> GetWishlist(Order order)
        {
            List<WLEventModel> wishlist = new List<WLEventModel>();
            WLEventModel eventItem = new WLEventModel();

            IEnumerable<Order> ordertjes = ihff.ORDER.Where(o => o.Code == order.Code);

            foreach (Order ordertje in ordertjes)
            {
                orderId = ordertje.Order_Id;
            }

            IEnumerable<Order_Items> itempies = ihff.ORDER_ITEMS.Where(oi => oi.Order_Id == orderId);

            List<Order_Items> items = itempies.ToList();

            foreach (Order_Items item in items)
            {
                if (item.Event_Id >= 1000 && item.Event_Id < 1037)
                {
                    IEnumerable<Film> film = ihff.FILMS.Where(f => f.Film_Id == item.Event_Id);

                    IEnumerable<DayTimeLocationModel> dTL = (IEnumerable<DayTimeLocationModel>)
                    (from f in ihff.FILMS
                     where item.Event_Id == f.Film_Id
                     join e in ihff.EVENTS
                     on f.Film_Id equals e.Film_Id
                     join l in ihff.LOCATIONS
                     on e.Location_Id equals l.Location_Id

                     select new DayTimeLocationModel
                     {
                         Day = e.Day,
                         Time = e.Time,
                         Location = l.Name
                     });
                    List<Film> Film = film.ToList();
                    List<DayTimeLocationModel> DTL = dTL.ToList();

                    foreach (Film f in Film)
                        foreach (DayTimeLocationModel d in DTL)
                        {
                            if (d.Day == item.Day && d.Time == item.Time)
                            {
                                wishlist.Add(new WLEventModel(f.Film_Id, f.Name, "Film", d, item.Amount, 7.50f));
                            }
                        }
                }
                else if (item.Event_Id >= 2000 && item.Event_Id < 2010)
                {
                    IEnumerable<Special> special = ihff.SPECIALS.Where(s => s.Special_Id == item.Event_Id);

                    IEnumerable<DayTimeLocationModel> dTL = (IEnumerable<DayTimeLocationModel>)
                    (from s in ihff.SPECIALS
                     where item.Event_Id == s.Special_Id
                     join e in ihff.EVENTS
                     on s.Special_Id equals e.Special_Id
                     join l in ihff.LOCATIONS
                     on e.Location_Id equals l.Location_Id

                     select new DayTimeLocationModel
                     {
                         Day = e.Day,
                         Time = e.Time,
                         Location = l.Name
                     });

                    List<Special> Special = special.ToList();
                    List<DayTimeLocationModel> DTL = dTL.ToList();

                    foreach (Special s in Special)
                        foreach (DayTimeLocationModel d in DTL)
                        {
                            if (d.Day == item.Day && d.Time == item.Time)
                            {
                                wishlist.Add(new WLEventModel(s.Special_Id, s.Name, "Film", d, item.Amount, 0f));
                            }
                        }
                }
                else if (item.Event_Id >= 4012 && item.Event_Id < 4017)
                {
                    IEnumerable<Restaurant> res = ihff.RESTAURANTS.Where(r => r.Restaurant_Id == item.Restaurant_Id);

                    IEnumerable<RestaurantAddressModel> resInfo = (IEnumerable<RestaurantAddressModel>)
                        (from r in ihff.RESTAURANTS
                         where item.Restaurant_Id == r.Restaurant_Id
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

                    foreach (Restaurant r in Restaurant)
                    {
                        foreach (RestaurantAddressModel a in Address)
                        {
                            wishlist.Add(new WLEventModel(r.Restaurant_Id, r.Name, "Restaurant", item.Day, item.Time, a, item.Amount, 10f));
                        }
                    }
                }
            }
            return wishlist;
        }
    }
}
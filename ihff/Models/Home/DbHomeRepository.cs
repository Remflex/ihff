using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbHomeRepository : IHomeRepository
    {
        private IhffContext ihff = new IhffContext();

        public List<HomeModel> GetSuggested()
        {
            Random random = new Random();
            int suggested = 0;
            int gelijk = 0;
            HomeModel filmOne, filmTwo, resOne, resTwo, spec, sight;
            List<HomeModel> home = new List<HomeModel>();

            for (int i = 0; i < 2; i++)
            {
                suggested = random.Next(1000, 1037);
                while (suggested == 1003 || suggested == 1021 || (suggested > 1022 && suggested < 1035))
                {
                    suggested = random.Next(1000, 1037);
                }
                IEnumerable<Film> film = ihff.FILMS.Where(f => f.Film_Id == suggested);

                if (i == 0)
                {
                    foreach (Film filmpje in film)
                    {
                        filmOne = new HomeModel(filmpje.Film_Id, "Film", filmpje.Name, filmpje.ShortDescription);
                        gelijk = suggested;
                        home.Add(filmOne);
                    }
                }
                else
                {
                    while (gelijk == suggested)
                    {
                        while (suggested == 1003 || suggested == 1021 || (suggested > 1022 && suggested < 1035))
                        {
                            suggested = random.Next(1000, 1037);
                        }
                    }
                    foreach (Film filmpje in film)
                    {
                        filmTwo = new HomeModel(filmpje.Film_Id, "Film", filmpje.Name, filmpje.ShortDescription);
                        home.Add(filmTwo);
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                suggested = random.Next(4012, 4017);

                IEnumerable<Restaurant> res = ihff.RESTAURANTS.Where(r => r.Restaurant_Id == suggested);

                if (i == 0)
                {
                    foreach (Restaurant resje in res)
                    {
                        resOne = new HomeModel(resje.Restaurant_Id, "Restaurant", resje.Name, resje.ShortDescription);
                        gelijk = suggested;
                        home.Add(resOne);
                    }
                }
                else
                {
                    while (gelijk == suggested)
                    {
                        suggested = random.Next(4012, 4017);
                    }

                    foreach (Restaurant resje in res)
                    {
                        resTwo = new HomeModel(resje.Restaurant_Id, "Restaurant", resje.Name, resje.ShortDescription);
                        home.Add(resTwo);
                    }
                }
            }

            suggested = random.Next(2000, 2010);
            IEnumerable<Special> special = ihff.SPECIALS.Where(s => s.Special_Id == suggested);
            foreach (Special specje in special)
            {
                spec = new HomeModel(specje.Special_Id, "Special", specje.Name, specje.ShortDescription);
                home.Add(spec);
            }

            suggested = random.Next(3000, 3009);
            IEnumerable<Sight> sights = ihff.SIGHTS.Where(s => s.Sight_Id == suggested);

            foreach (Sight sightje in sights)
            {
                sight = new HomeModel(sightje.Sight_Id, "Sight", sightje.Name, sightje.ShortDescription);
                home.Add(sight);
            }

            return home;
        }
    }
}
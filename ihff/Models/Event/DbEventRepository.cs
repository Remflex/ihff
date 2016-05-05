using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbEventRepository : IEventRepository
    {
        private IhffContext ihff = new IhffContext();

        public List<DayTimeLocationModel> GetAllShowings(int id)
        {
            IEnumerable<DayTimeLocationModel> dTL = (IEnumerable<DayTimeLocationModel>)
            (from f in ihff.FILMS
             where id == f.Film_Id
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

            List<DayTimeLocationModel> DTL = dTL.ToList();

            return (DTL);
        }
    }
}
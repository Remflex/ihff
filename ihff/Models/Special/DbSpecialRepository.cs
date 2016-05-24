using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbSpecialRepository : ISpecialRepository
    {
        IhffContext ihff = new IhffContext();

        public IEnumerable<Special> GetAllSpecials()
        {
            IEnumerable<Special> allSpecials = ihff.SPECIALS;

            return allSpecials;
        }

        public IEnumerable<SpecialModel> GetDaySpecials()
        {
            IEnumerable<SpecialModel> daySpecials = (IEnumerable<SpecialModel>)
            (from s in ihff.SPECIALS
             join e in ihff.EVENTS
                 on s.Special_Id equals e.Special_Id
             join l in ihff.LOCATIONS
                 on e.Location_Id equals l.Location_Id
             select new SpecialModel
             {
                 Special_Id = s.Special_Id,
                 Name = s.Name,
                 ShortDescription = s.ShortDescription,
                 Salutation = s.Salutation,
                 Led_By = s.Led_By,
                 ExtraInfo = s.ExtraInfo,
                 Day = e.Day,
                 Time = e.Time,
                 Location = l.Name
             });

            return daySpecials;
        }

        public SpecialInformationModel GetSpecialInformation(int specId)
        {
            IEnumerable<Special> special = ihff.SPECIALS.Where(s => s.Special_Id == specId);

            IEnumerable<DayTimeLocationModel> dTL = (IEnumerable<DayTimeLocationModel>)
            (from s in ihff.SPECIALS
             where specId == s.Special_Id
             join e in ihff.EVENTS
             on s.Special_Id equals e.Film_Id
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

            SpecialInformationModel specialInformation = new SpecialInformationModel(Special, DTL);

            return specialInformation;
        }
    }
}
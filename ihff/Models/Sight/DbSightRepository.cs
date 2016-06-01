using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ihff.Models
{
    public class DbSightRepository : ISightRepository
    {
        private IhffContext ihff = new IhffContext();

        public IEnumerable<Sight> GetAllSights()
        {
            IEnumerable<Sight> allSights = ihff.SIGHTS;
            return allSights;
        }



    }
}
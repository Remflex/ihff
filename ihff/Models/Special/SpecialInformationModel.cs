using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class SpecialInformationModel
    {
        public List<Special> Special { get; set; }
        public List<DayTimeLocationModel> DTL { get; set; }

        public SpecialInformationModel()
        {

        }

        public SpecialInformationModel(List<Special> spec, List<DayTimeLocationModel> dtl)
        {
            this.Special = Special;
            this.DTL = dtl;
        }
    }
}
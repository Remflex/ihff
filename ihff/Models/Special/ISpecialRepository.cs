using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ihff.Models
{
    interface ISpecialRepository
    {
        IEnumerable<Special> GetAllSpecials();
        IEnumerable<SpecialModel> GetDaySpecials();
        SpecialInformationModel GetSpecialInformation(int specId);
    }
}

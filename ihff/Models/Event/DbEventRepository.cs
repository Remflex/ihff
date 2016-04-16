using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class DbEventRepository : IEventRepository
    {
        private IhffContext ctx = new IhffContext();

        public IEnumerable<Event> GetAllEvents()
        {
            IEnumerable<Event> allEvents = ctx.Events;
            return allEvents;
        }
    }
}
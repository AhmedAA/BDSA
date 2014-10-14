using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Model.Event
{
    class Event : EventItem
    {
        public Event(DateTime startDate, DateTime endDate, string title, string description = "") : base(startDate, endDate, title, description)
        {
        }
    }
}

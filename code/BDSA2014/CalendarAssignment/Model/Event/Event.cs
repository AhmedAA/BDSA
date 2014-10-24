using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Model.Event
{
    class Event : EventItem
    {
        /**
         * Invariants:
         * A user must be logged in
         * @invariant: activeUser == 1
         * An event must be added to a calendar
         * @invariant: calendars > 0
         */
        public Event(DateTime startDate, DateTime endDate, string title, string description = "") : base(startDate, endDate, title, description)
        {
        }
    }
}

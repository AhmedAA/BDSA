using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Controller;
using CalendarAssignment.Model.Event;

namespace CalendarAssignment.Model
{
    class Calendar
    {        
        public string Title { get; set; }
        public bool IsPublicCalendar { get; set; }
        public bool IsSynced { get; set; }
        public List<EventItem> Events { get; set; }
        public User Owner { get; set; }
    }
}

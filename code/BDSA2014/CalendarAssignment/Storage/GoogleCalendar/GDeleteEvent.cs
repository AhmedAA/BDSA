using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Commands;
using CalendarAssignment.Model.Event;

namespace CalendarAssignment.Storage.GoogleCalendar
{
    class GDeleteEvent : ICommand
    {
        public GoogleCalendar GoogleCalendarInstance { get; set; }
        public int Id { get; set; }
        public int CalendarId { get; set; }
        public Event Event { get; set; }

        public bool Execute()
        {
            var eventString = GoogleCalendarInstance.GetEvent(CalendarId.ToString(), Id.ToString());
            Event = new Event(DateTime.Parse("10-10-2014 10:10:10"), DateTime.Parse("11-11-2014 20:20:20"), "SomeTitle"); // Fetch all the information from the eventString. (This is used for Undo).
            var result = GoogleCalendarInstance.DeleteEvent(Id.ToString());
            throw new NotImplementedException();
        }

        public bool Undo()
        {
            var result = GoogleCalendarInstance.CreateEvent(CalendarId.ToString(), Event.StartDate, Event.EndDate, "", 0,
                Event.Title, Event.Description);
            throw new NotImplementedException();
        }
    }
}

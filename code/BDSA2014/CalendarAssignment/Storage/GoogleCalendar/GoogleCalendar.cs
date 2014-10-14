using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Storage.GoogleCalendar
{
    class GoogleCalendar
    {
        public string ApiUri { get; set; }

        public string GetCalendar(string calendarId)
        {
            throw new NotImplementedException();
        }

        public string CreateCalendar(string title, string description, string location, string timeZone)
        {
            throw new NotImplementedException();
        }

        public string UpdateCalendar(string calendarId, string title, string description, string location, string timeZone)
        {
            throw new NotImplementedException();
        }

        public string GetEvent(string calendarId, string eventId)
        {
            throw new NotImplementedException();
        }

        public string GetEvents(string calendarId)
        {
            throw new NotImplementedException();
        }

        public string CreateEvent(string calendarId, DateTime start, DateTime end, string method, int minutesReminder, string title, string description)
        {
            throw new NotImplementedException();
        }

        public string DeleteEvent(string eventId)
        {
            throw new NotImplementedException();
        }

        public string UpdateEvent(string calendarId, string eventId, DateTime start, DateTime end, string method, int minutesReminder, string title, string description)
        {
            throw new NotImplementedException();
        }
    }
}

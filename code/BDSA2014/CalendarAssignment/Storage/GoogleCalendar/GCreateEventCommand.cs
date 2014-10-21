using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Commands;

namespace CalendarAssignment.Storage.GoogleCalendar
{
    class GCreateEventCommand : ICommand
    {
        public GoogleCalendar GoogleCalendarInstance { get; set; }
        public int Id { get; set; }
        public int CalendarId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Method { get; set; }
        public int MinutesReminder { get; set; }

        public bool Execute()
        {
            var result = GoogleCalendarInstance.CreateEvent(CalendarId.ToString(), Start, End, Method, MinutesReminder, Title, Description);
            throw new NotImplementedException();
        }

        public bool Undo()
        {
            var result = GoogleCalendarInstance.DeleteEvent(Id.ToString());
            throw new NotImplementedException();
        }
    }
}

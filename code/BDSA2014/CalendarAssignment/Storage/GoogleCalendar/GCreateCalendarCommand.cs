using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Commands;

namespace CalendarAssignment.Storage.GoogleCalendar
{
    class GCreateCalendarCommand : ICommand
    {
        public GoogleCalendar GoogleCalendarInstance { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string TimeZone { get; set; }

        public bool Execute()
        {
            var result = GoogleCalendarInstance.CreateCalendar(Title, Description, Location, TimeZone);
            throw new NotImplementedException();
        }

        public bool Undo()
        {
            var result = GoogleCalendarInstance.DeleteCalendar(Id.ToString());
            throw new NotImplementedException();
        }
    }
}

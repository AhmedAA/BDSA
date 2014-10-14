using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;

namespace CalendarAssignment.Storage.GoogleCalendar
{
    /// <summary>
    /// This class is used to map from storage in the system to storage on Google Calendar.
    /// The adapter needs to implement all the same methods as the rest of the storage solutions,
    /// but maps these to the correct methods on the GoogleCalendar class, which speaks with the api.
    /// </summary>
    class GoogleCalendarAdapter : IStorage
    {
        public GoogleCalendar GoogleCalendarInstance { get; set; }

        public void CreateCalendar(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public Calendar[] ReadCalendars()
        {
            throw new NotImplementedException();
        }

        public Calendar[] ReadCalendars(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateCalendar(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public void DeleteCalendar(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public User ReadUsers()
        {
            throw new NotImplementedException();
        }
    }
}

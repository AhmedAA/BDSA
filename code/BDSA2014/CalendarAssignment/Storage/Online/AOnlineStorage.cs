using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;

namespace CalendarAssignment.Storage.Online
{
    abstract class AOnlineStorage : IStorage
    {
        public string Url { get; set; }
        public int Port { get; set; }
        /// <summary>
        /// IsConnected is true, if there is a connection to the server.
        /// Check this before trying to write to the server and abort if not connected.
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// CheckConnection checks if it can access the server on the given location (url) with the given port.
        /// It will set the IsConnected property. This method should be called regularly, perhaps before each call to the server.
        /// </summary>
        public bool CheckConnection()
        {
            throw new NotImplementedException();
        }
        
        /**
         * Pre conditions
         * context AOnlineStorage::CreateCalendar pre:
         *      isUserLoggedIn
         * context AOnlineStorage::CreateCalendar pre:
         *      isCalendarCreatedToUser
         *      
         * Post conditions
         * context AOnlineStorage::CreateCalendar post:
         *      isCalendarAdded
         * context AOnlineStorage::CreateCalendar post:
         *      calendarIsOnUser
         */
        public abstract void CreateCalendar(Calendar calendar);
        public abstract Calendar[] ReadCalendars();
        public abstract Calendar[] ReadCalendars(User user);
        public abstract void UpdateCalendar(Calendar calendar);
        public abstract void DeleteCalendar(Calendar calendar);
        public abstract User ReadUsers();
    }
}

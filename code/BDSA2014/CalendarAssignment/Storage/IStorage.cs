using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;

namespace CalendarAssignment.Storage
{
    interface IStorage
    {
        /**
         * Pre conditions
         * context IStorage::CreateCalendar pre:
         *      isUserLoggedIn
         * context IStorage::CreateCalendar pre:
         *      isCalendarCreatedToUser
         *      
         * Post conditions
         * context IStorage::CreateCalendar post:
         *      isCalendarAdded
         * context IStorage::CreateCalendar post:
         *      calendarIsOnUser
         */
        void CreateCalendar(Calendar calendar);
        Calendar[] ReadCalendars();
        Calendar[] ReadCalendars(User user);
        void UpdateCalendar(Calendar calendar);
        void DeleteCalendar(Calendar calendar);
        User ReadUsers();

    }
}

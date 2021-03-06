﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;
using CalendarAssignment.Storage.Online;

namespace CalendarAssignment.Storage
{
    class FileStorage : IStorage
    {
        public string Path { get; set; }

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

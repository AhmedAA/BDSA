﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;

namespace CalendarAssignment.Storage
{
    class DbStorage : IStorage
    {
        public string DatabaseName { get; set; }
        public string DatabasePassword { get; set; }
        public string DatabaseUrl { get; set; }

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

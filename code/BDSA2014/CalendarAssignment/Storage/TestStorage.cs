using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;

namespace CalendarAssignment.Storage
{
    class TestStorage : IStorage
    {
        private List<Calendar> _calendarList = new List<Calendar>();
        private List<User> _userList = new List<User>();

        public void SetCalendarList(List<Calendar> calendarList)
        {
            _calendarList = calendarList;
        }

        public void SetUserList(List<User> userList)
        {
            _userList = userList;
        }

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

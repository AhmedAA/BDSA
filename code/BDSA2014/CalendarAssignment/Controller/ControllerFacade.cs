using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;
using CalendarAssignment.Model.Event;
using CalendarAssignment.Storage;
using CalendarAssignment.Storage.Online;

namespace CalendarAssignment.Controller
{
    class ControllerFacade : IControllerFacade
    {
        private static ControllerFacade _thisController;

        public static ControllerFacade GetControllerFacade()
        {
            if (_thisController == null)
            {
                _thisController = new ControllerFacade();
            }
            return _thisController;
        }

        public User LoggedInUser { get; private set; } // filled out by calling login (further down)
        public StorageContext StorageContext { get; set; }

        public Calendar AddCalendar(string title, bool isPublic, User owner)
        {
            throw new NotImplementedException();
        }

        public Event AddEvent(Calendar calender, DateTime startDate, DateTime endDate, string title)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void RemoveCalendar(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public void RemoveEvent(Event givenEvent)
        {
            throw new NotImplementedException();
        }

        public Collection<Calendar> GetCalendars()
        {
            throw new NotImplementedException();
        }

        public Collection<Event> GetEvents(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public void LogIn(string username, string password)
        {
            User user = new User() {Username = username, HashedPassword = password, IsLoggedIn = true};
            LoggedInUser = user;
        }

        public void LogOut(User user)
        {
            throw new NotImplementedException();
        }

        public void ChangeTitle(Event givenEvent, string title)
        {
            throw new NotImplementedException();
        }

        public void ChangeDescription(Event givenEvent, string description)
        {
            throw new NotImplementedException();
        }

        public void ChangeDates(Event givenEvent, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void SelectEvent(Event givenEvent)
        {
            throw new NotImplementedException();
        }

        public void SelectCalendar(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public void MakeCalendarPublic(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public void MakeCalendarUnpublic(Calendar calendar)
        {
            throw new NotImplementedException();
        }
    }
}

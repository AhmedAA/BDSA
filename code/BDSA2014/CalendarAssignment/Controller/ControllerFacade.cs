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
    abstract class ControllerFacade : IControllerFacade
    {
        public User LoggedInUser { get; private set; } // filled out by calling login (further down)
        public StorageContext StorageContext { get; set; }
        public abstract Calendar AddCalendar(string title, bool isPublic, User owner);
        public abstract Event AddEvent(Calendar calender, DateTime startDate, DateTime endDate, string title);
        public abstract User CreateUser(string username, string password);
        public abstract void RemoveCalendar(Calendar calendar);
        public abstract void RemoveEvent(Event givenEvent);
        public abstract Collection<Calendar> GetCalendars();
        public abstract Collection<Event> GetEvents(Calendar calendar);
        public abstract User LogIn(string username, string password);
        public abstract void LogOut(User user);
        public abstract void ChangeTitle(Event givenEvent, string title);
        public abstract void ChangeDescription(Event givenEvent, string description);
        public abstract void ChangeDates(Event givenEvent, DateTime startDate, DateTime endDate);
        public abstract void SelectEvent(Event givenEvent);
        public abstract void SelectCalendar(Calendar calendar);
        public abstract void MakeCalendarPublic(Calendar calendar);
        public abstract void MakeCalendarUnpublic(Calendar calendar);
    }
}

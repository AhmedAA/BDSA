using System;
using System.Collections.ObjectModel;
using CalendarAssignment.Model;
using CalendarAssignment.Model.Event;

namespace CalendarAssignment.Controller
{
    interface IControllerFacade
    {
        Calendar AddCalendar(string title, bool isPublic, User owner);
        Event AddEvent(Calendar calender, DateTime startDate, DateTime endDate, string title);
        User CreateUser(string username, string password);
        void RemoveCalendar(Calendar calendar);
        void RemoveEvent(Event givenEvent);
        Collection<Calendar> GetCalendars();
        Collection<Event> GetEvents(Calendar calendar);
        User LogIn(string username, string password);
        void LogOut(User user);
        void ChangeTitle(Event givenEvent, string title);
        void ChangeDescription(Event givenEvent, string description);
        void ChangeDates(Event givenEvent, DateTime startDate, DateTime endDate);
        void SelectEvent(Event givenEvent);
        void SelectCalendar(Calendar calendar);
        void MakeCalendarPublic(Calendar calendar);
        void MakeCalendarUnpublic(Calendar calendar);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;

namespace CalendarAssignment
{
    interface IModelRepository
    {
        void AddCalendar(Calendar calendar);
        void AddEvent(Event givenEvent);
        User AddUser(string username, string password);
        void RemoveCalendar(Calendar calendar);
        void RemoveEvent(Event givenEvent);
        User RemoveUser(string username, string password);
    }
}

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

        void CreateCalendar(Calendar calendar);
        Calendar[] ReadCalendars();
        Calendar[] ReadCalendars(User user);
        void UpdateCalendar(Calendar calendar);
        void DeleteCalendar(Calendar calendar);
        User ReadUsers();

    }
}

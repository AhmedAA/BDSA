using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Model;

namespace CalendarAssignment.Storage.Factory
{
    class TestStorageFactory : IStorageFactory
    {
        public IStorage CreateStorage()
        {
            var testStorage = new TestStorage();
            testStorage.SetCalendarList(new List<Calendar>() { new Calendar() { Title = "Personal Calendar" }, new Calendar() { Title = "Work Calendar" } });
            testStorage.SetUserList(new List<User>() { new User() { Username = "peter.mars" }, new User() { Username = "maria-1992" } });
            return testStorage;
        }
    }
}

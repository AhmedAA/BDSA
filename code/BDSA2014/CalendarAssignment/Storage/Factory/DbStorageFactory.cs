using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Storage.Factory
{
    class DbStorageFactory
    {

        public string DatabaseName { get; set; }
        public string DatabasePassword { get; set; }
        public string DatabaseUrl { get; set; }

        public IStorage CreateStorage()
        {
            return new DbStorage() { DatabaseName = DatabaseName, DatabasePassword = DatabasePassword, DatabaseUrl = DatabaseUrl };
        }

    }
}

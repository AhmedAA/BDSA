using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Storage.Factory
{
    class FileStorageFactory : IStorageFactory
    {
        public string Path { get; set; }

        public IStorage CreateStorage()
        {
            return new FileStorage() { Path = Path };
        }
    }
}

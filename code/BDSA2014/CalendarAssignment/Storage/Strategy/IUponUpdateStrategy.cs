using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Storage.Online;

namespace CalendarAssignment.Storage.Strategy
{
    interface IUponUpdateStrategy
    {
        IStorage[] GetStorages(IStorage localStorage, AOnlineStorage onlineStorage);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Storage.Online;

namespace CalendarAssignment.Storage.Strategy
{
    class NotConnectedStrategy : IUponUpdateStrategy
    {
        public IStorage[] GetStorages(IStorage localStorage, AOnlineStorage onlineStorage)
        {
            return new IStorage[] {localStorage};
        }
    }
}

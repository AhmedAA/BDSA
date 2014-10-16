using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAssignment.Storage.Online;
using CalendarAssignment.Storage.Strategy;

namespace CalendarAssignment.Storage
{
    class StorageContext
    {
        private IStorage LocalStorage { get; set; }
        private AOnlineStorage OnlineStorage { get; set; }
        private IUponUpdateStrategy Strategy { get; set; }
        public StorageContext(IStorage localStorage, AOnlineStorage aOnlineStorage)
        {
            LocalStorage = localStorage;
            OnlineStorage = OnlineStorage;
            if (OnlineStorage.CheckConnection())
            {
                Strategy = new ConnectedStrategy();
            }
            else
            {
                Strategy = new NotConnectedStrategy();
            }
        }

        public IStorage[] GetStorages()
        {
            return Strategy.GetStorages(LocalStorage, OnlineStorage);
        }

        public void UpdateStrategy()
        {
            if (OnlineStorage.CheckConnection())
            {
                Strategy = new ConnectedStrategy();
            }
            else
            {
                Strategy = new NotConnectedStrategy();
            }
        }

    }
}

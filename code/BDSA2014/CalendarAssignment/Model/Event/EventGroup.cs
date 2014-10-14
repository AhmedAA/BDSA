using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Model.Event
{
    class EventGroup : EventItem
    {
        private List<EventItem> _eventItemList = new List<EventItem>();

        public EventGroup(DateTime startDate, DateTime endDate, string title, string description = "") : base(startDate, endDate, title, description)
        {
        }

        public void AddEventItem(EventItem eventItem)
        {
            _eventItemList.Add(eventItem);
            eventItem.Group = this;
        }

        public void RemoveEventItem(EventItem eventItem)
        {
            _eventItemList.Remove(eventItem);
            eventItem.Group = null;
        }

        public EventItem[] GetEventItems()
        {
            return _eventItemList.ToArray();
        }

    }
}

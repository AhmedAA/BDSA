using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Model.Event
{
    class EventGroup : EventItem
    {
        /**
         * Invariants:
         * A user must be logged in
         * @invariant: activeUser == 1
         * Events must be added to calendars
         * @invariant: calendars > 0
         */
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

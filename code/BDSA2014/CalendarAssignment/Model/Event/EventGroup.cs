using CalendarAssignment.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        [ContractInvariantMethod]
        protected void EventgroupInvariant()
        {
            Contract.Invariant(ControllerFacade.GetControllerFacade().LoggedInUser.IsLoggedIn == true);
            Contract.Invariant(calendars > 0); //TODO Somehow
            /**
            * Invariants:
            * 
            * A user must be logged in
            * @invariant: one active user only
            * context EventGroup inv:
            *  'UserLoggedIn() == true'
            *  
            * @invariant: Events must be added to calendars
            * context EventGroup inv:
            * 'Calendars > 0'
            */
            throw new Exception(Contract.ContractFailed.Message());
        }
    }
}

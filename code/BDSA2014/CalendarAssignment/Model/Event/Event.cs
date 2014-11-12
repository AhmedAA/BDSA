using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Model.Event
{
    class Event : EventItem
    {

        public Event(DateTime startDate, DateTime endDate, string title, string description = "") : base(startDate, endDate, title, description)
        {
        }

        [ContractInvariantMethod]
        protected void EventInvariant()
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

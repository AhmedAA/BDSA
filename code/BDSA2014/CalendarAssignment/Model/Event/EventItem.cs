using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAssignment.Model.Event
{
    class EventItem
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // This property is set from within the EventGroup class, when attached to a group.
        public EventGroup Group { get; set; }

        /**
         * Pre conditions
         * context EventItem::EventItem pre:
         *      isCalendarSelected()
         * context EventItem::EventItem pre:
         *      isDataSet()
         *      
         * Post conditions
         * context EventItem::EventItem post:
         *      isEventAdded()
         * context EventItem::EventItem post:
         *      isEventInCalendar()
         */
        public EventItem(Calendar calendar, DateTime startDate, DateTime endDate, string title, string description = "")
        {
            // TODO: Assert data isn't null somehow?
            calendar.Events.Add(this);
            StartDate = startDate;
            EndDate = endDate;
            Title = title;
            Description = description;
        }

        /**
         * Pre conditions
         * context EventItem::ChangeDates pre:
         *      isEventInCalendar()
         * context EventItem::ChangeDates pre:
         *      eventIsVisible()
         *      
         * Post conditions
         * context EventItem::ChangeDates post:
         *      isDateChanged()
         * context EventItem::ChangeDates post:
         *      isDateCorrect()
         */
        public void ChangeDates(DateTime startDate, DateTime endDate)
        {
            if ((this.StartDate != startDate) || (this.EndDate != endDate))
            {
                StartDate = startDate;
                EndDate = endDate;
            }
            else
            {
                this.StartDate = StartDate;
                this.EndDate = EndDate;
            }
        }

        public void ChangeTitle(string title)
        {
            Title = title;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }
    }
}

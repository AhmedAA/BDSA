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

        public EventItem(DateTime startDate, DateTime endDate, string title, string description = "")
        {
            StartDate = startDate;
            EndDate = endDate;
            Title = title;
            Description = description;
        }

        public void ChangeDates(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
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

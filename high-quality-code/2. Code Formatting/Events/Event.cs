using System;
using System.Text;

namespace Events
{ 
    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int dateDifference = this.date.CompareTo(other.date);
            int titleDifference = this.title.CompareTo(other.title);
            int locationDifference = this.location.CompareTo(other.location);

            if (dateDifference == 0)
            {
                if (titleDifference == 0)
                {
                    return locationDifference;
                }
                else
                {
                    return titleDifference;
                }
            }
            else
            {
                return dateDifference;
            }             
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);

            if (this.location != null && this.location != string.Empty)
            {
                toString.Append(" | " + this.location);
            }
 
            return toString.ToString();
        }
    }
}

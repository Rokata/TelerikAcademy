using System;

namespace GSMCallHistoryTest
{
    class Call
    {
        private DateTime date;
        private long dialedPhone;
        private int duration;

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value == null) throw new ArgumentException("Invalid value!");
                this.date = value;
            }
        }

        public long DialedPhone
        {
            get
            {
                return this.dialedPhone;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value!");
                this.dialedPhone = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value!");
                this.duration = value;
            }
        }

        public Call(DateTime date, long dialedPhone, int duration)
        {
            this.date = date;
            this.dialedPhone = dialedPhone;
            this.duration = duration;
        }

        public override string ToString()
        {
            return string.Format("Date: {0}\nDialed phone: {1}\nDuration: {2} sec.\n",
                date, dialedPhone, duration);
        }
    }
}

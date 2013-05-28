using System;
using System.Threading;

namespace PublishEvents
{
    class Publisher
    {
        public event EventHandler<CustomEventArgs> CustomEvent;
        private int digit;
        private int timeInSeconds;

        public Publisher(int seconds)
        {
            this.digit = 1;
            this.timeInSeconds = seconds;
        }

        public void ShowDigitValue()
        {
            OnRaiseCustomEvent(new CustomEventArgs("value now is " + digit));
            digit++;
            Thread.Sleep(timeInSeconds * 1000);
        }

        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = CustomEvent;
            if (handler != null) handler(this, e);
        }
    }
}

using System;
using System.Threading;

namespace Timer
{
    public class Timer
    {
        private PrintDelegate del;
        private int timeInSeconds;
        private int digit;

        public PrintDelegate Del
        {
            get { return this.del; }
        }

        public Timer(int t)
        {
            del = new PrintDelegate(PrintNumber);
            this.timeInSeconds = t;
            this.digit = 1;
        }

        public void PrintNumber()
        {
            Console.WriteLine("Printing " + digit);
            digit++;
            Thread.Sleep(timeInSeconds * 1000);
        }
    }
}

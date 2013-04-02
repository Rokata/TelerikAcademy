using System;
using System.Threading;

namespace Timer
{
    public delegate void PrintDelegate();

    class TimerDemo
    {
        static void Main()
        {
            Timer timer = new Timer(3);
            DateTime now = DateTime.Now;
            DateTime future = now.AddSeconds(10);

            while (now < future)
            {
                timer.Del();
                now = DateTime.Now;
            }
        }
    }
}

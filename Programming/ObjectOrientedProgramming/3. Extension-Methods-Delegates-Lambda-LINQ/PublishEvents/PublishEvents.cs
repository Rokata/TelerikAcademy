using System;
using System.Collections.Generic;
using System.Threading;

namespace PublishEvents
{
    class PublishEvents
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher(3);
            Subscriber sub1 = new Subscriber(pub, "Subscriber 1");

            DateTime now = DateTime.Now;
            DateTime future = now.AddSeconds(10);

            while (now < future)
            {
                pub.ShowDigitValue();
                now = DateTime.Now;
            }
        }
    }
}

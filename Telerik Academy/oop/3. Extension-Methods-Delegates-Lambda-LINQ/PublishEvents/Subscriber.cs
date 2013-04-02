using System;

namespace PublishEvents
{
    class Subscriber
    {
        private string name;

        public Subscriber(Publisher pub, string name)
        {
            pub.CustomEvent += HandleCustomEvent;
            this.name = name;
        }

        public void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine(name + " received message: {0}", e.Message);
        }
    }
}

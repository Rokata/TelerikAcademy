using System;
using System.Collections.Generic;
using System.Globalization;

namespace GSMCallHistoryTest
{
    class GSM
    {
        private string model;
        private string manufacturer;
        private double price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;
        public static GSM iPhone4S = null;

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
            set { iPhone4S = value; }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid model name!");
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid manufacturer name!");
                this.manufacturer = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value!");
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid owner name!");
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                if (value == null) throw new ArgumentException("Battery information should not be set to null!");
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                if (value == null) throw new ArgumentException("Display information should not be set to null!");
                this.display = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        public GSM(string model, string manufacturer, double price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = null;
            this.battery = null;
            this.display = null;
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price, string owner)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = null;
            this.display = null;
            this.callHistory = new List<Call>();
        }

        public override string ToString()
        {
            return string.Format("Model: {0}\nManufacturer: {1}\nPrice: {2}\nOwner: {3}\n\n--- Battery info --- \n{4}\n" +
                "--- Display info ---\n{5}\n"
                , model, manufacturer, price, owner, battery.ToString(), display.ToString());
        }

        public void AddNewCall(Call call)
        {
            callHistory.Add(call);
        }

        public void RemoveCall(int callDuration)
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                if (callHistory[i].Duration == callDuration)
                {
                    callHistory.RemoveAt(i);
                    break;
                }
            }
        }

        public int FindLongestCall()
        {
            int maxDuration = 0;

            foreach (Call call in callHistory)
            {
                if (call.Duration > maxDuration) maxDuration = call.Duration;
            }

            return maxDuration;
        }

        public void ClearCallHistory()
        {
            callHistory.Clear();
        }

        public double CalculateTotalPrice(double price)
        {
            double total = 0;
            int minutes = 0;

            foreach (Call call in callHistory)
            {
                minutes = call.Duration / 60;
                if (call.Duration % 60 > 0) total += (minutes + 1) * price;
                else total += minutes * price;
            }

            return total;
        }
    }
}

using System;

namespace GSMCallHistoryTest
{
    public enum BatteryType { LiIon, NiMH, NiCd };

    class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType type;

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

        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value!");
                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value!");
                this.hoursTalk = value;
            }
        }

        public BatteryType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType type)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.type = type;
        }

        public Battery(string model, BatteryType type)
        {
            this.model = model;
            this.type = type;
        }

        public Battery(string model, int hoursIdle, BatteryType type)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.type = type;
        }

        public override string ToString()
        {
            return string.Format("Battery model: {0}\nBattery hrs idle: {1}\nBattey hrs talk: {2}\nBattery type: {3}\n",
                model, hoursIdle, hoursTalk, type);
        }
    }

}
using System;

namespace GSMCallHistoryTest
{
    class Display
    {
        private int size;
        private int colors;

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value!");
                this.size = value;
            }
        }

        public int Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value!");
                this.colors = value;
            }
        }

        public Display(int size, int colors)
        {
            this.size = size;
            this.colors = colors;
        }

        public Display(int size)
        {
            this.size = size;
        }

        public Display()
        {
        }

        public override string ToString()
        {
            return string.Format("Size: {0}\nColors: {1}", size, colors);
        }
    }
}

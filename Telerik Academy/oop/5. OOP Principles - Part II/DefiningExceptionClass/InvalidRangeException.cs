using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningExceptionClass
{
    public class InvalidRangeException<T> : ApplicationException
    {
        private readonly T startRange;
        private readonly T endRange;

        public override string Message
        {
            get
            {
                return string.Format("Value out of range. The value must be between {0} and {1}",
                    startRange, endRange);
            }
        }

        public InvalidRangeException(string msg) : base(msg) { }

        public InvalidRangeException(T startRange, T endRange)
        {
            this.startRange = startRange;
            this.endRange = endRange;
        }

    }
}

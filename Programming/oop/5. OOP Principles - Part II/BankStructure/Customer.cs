using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankStructure
{
    public abstract class Customer
    {
        private long telephone;

        public long Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public Customer(long telephone)
        {
            this.telephone = telephone;
        }
    }
}

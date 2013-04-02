using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankStructure
{
    public abstract class Account : IDepositable
    {
        private Customer customer;
        private double balance;
        private double interestRate;

        public Account(Customer customer, double balance, double interestRate)
        {
            this.customer = customer;
            this.balance = balance;
            this.interestRate = interestRate;
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public double InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        public virtual void DepositMoney(double amount)
        {
            balance += amount;
        }

        public abstract double CalculateInterest(int month);
    }
}

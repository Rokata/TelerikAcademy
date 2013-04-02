using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankStructure
{
    public class DepositAccount : Account, IWithdrawable
    {
        public DepositAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        { }

        public void WithdrawMoney(double amount)
        {
            this.Balance -= amount;
        }

        public override double CalculateInterest(int month)
        {
            if (Balance > 0 && Balance < 1000) return InterestRate;

            return (month * InterestRate);
        }
    }
}

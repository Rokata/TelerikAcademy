using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankStructure
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate) { }

        public override double CalculateInterest(int month)
        {
            string customerType = this.Customer.GetType().Name;
            double futureBalance = Balance;
            int noRateMonthsCount = 0;

            switch (customerType)
            {
                case "CompanyCustomer":
                    {
                        if (month <= 2) return InterestRate;
                        noRateMonthsCount = 2;
                        break;
                    }
                case "IndividualCustomer":
                    {
                        if (month <= 3) return InterestRate;
                        noRateMonthsCount = 3;
                        break;
                    }
            }

            return (month - noRateMonthsCount) * InterestRate;
        }
    }
}

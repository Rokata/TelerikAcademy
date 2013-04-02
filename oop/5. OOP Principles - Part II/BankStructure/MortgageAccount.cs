using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankStructure
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate) { }

        public override double CalculateInterest(int month)
        {
            string customerType = this.Customer.GetType().Name;

            switch (customerType)
            {
                case "CompanyCustomer":
                    {
                        if (month <= 12) return ((InterestRate / 2) * month);
                        else
                        {
                            return (InterestRate * (month - 12) + (InterestRate / 2) * 12);
                        }
                    }
                case "IndividualCustomer":
                    {
                        if (month <= 6) return InterestRate;
                        else
                        {
                            return (InterestRate * (month - 5)); // equivalent to (InterestRate * (month - 6) + InterestRate)
                        }
                    }

                default: return -1;
            }
        }
    }
}

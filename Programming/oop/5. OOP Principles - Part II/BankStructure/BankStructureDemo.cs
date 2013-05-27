using System;

namespace BankStructure
{
    class BankStructureDemo
    {
        static void Main()
        {
            MortgageAccount macc = new MortgageAccount(new IndividualCustomer(38493894), 140.50, 3.3);
            Console.WriteLine(macc.CalculateInterest(12));

            macc.Customer = new CompanyCustomer(83478347);
            Console.WriteLine(macc.CalculateInterest(12));
        }
    }
}

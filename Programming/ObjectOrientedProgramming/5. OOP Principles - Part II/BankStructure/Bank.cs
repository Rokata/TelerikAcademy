using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankStructure
{
    public class Bank
    {
        private List<Account> accountsList;

        public Bank(List<Account> accountsList)
        {
            this.accountsList = accountsList;
        }

        public Bank()
        {
            this.accountsList = new List<Account>();
        }

        public List<Account> AccountsList
        {
            get { return accountsList; }
        }

        public void AddAccount(Account acc)
        {
            accountsList.Add(acc);
        }
    }
}

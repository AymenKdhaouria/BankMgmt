using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountManagement.Services
{
    public class TransactionService : ITransactionService
    {
        //Attributes
        private List<Customer> listofcustomers;

        //Properties
        public List<Customer> ListOfCustomers { get => listofcustomers; set => listofcustomers = value; }

        //Methods
        public TransactionService()
        {
            listofcustomers = new List<Customer>();
        }

        public TransactionService(List<Customer> listofcustomers)
        {
            this.listofcustomers = new List<Customer>();
            this.listofcustomers.AddRange(listofcustomers);
        }
        
        public void Deposit(string accountid, decimal amount)
        {
            Account account = ListOfCustomers.SelectMany(p => p.ListOfAccounts).Where(a => a.AccountId == accountid).SingleOrDefault();
 
            if (account != null)
            {
                if (amount <= 0)
                    throw new Exception("Amount cannot be less or equal to zero.");
                account.Deposit(amount);
            }
            else
            {
                throw new Exception("Account not found!");
            }

        }

        public void Withdraw( string accountid, decimal amount)
        {
            Account account = ListOfCustomers.SelectMany(p => p.ListOfAccounts).Where(a => a.AccountId == accountid).SingleOrDefault();
            if (account != null)
            {
                if (account.Balance < amount)
                    throw new Exception("Not enough balance for this withdrawl");

                account.Withdraw(amount);
            }
            else
            {
                throw new Exception("Account not found!");
            }
        }
    }
}

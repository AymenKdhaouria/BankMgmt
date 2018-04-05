using BankAccountManagement.Interfaces;
using System.Collections.Generic;

namespace BankAccountManagement.Services
{
    public class Customer : ICustomer
    {
        //Attributes
        private string customerid;
        private List<Account> listofaccounts;

        //Properties
        public string CustomerId { get => customerid; set => customerid = value; }
        public List<Account> ListOfAccounts { get => listofaccounts; set => listofaccounts = value; }

        //Methods
        public Customer()
        {
            listofaccounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {            
            listofaccounts.Add(account);
        }
    }
}

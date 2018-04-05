using System.Collections.Generic;

namespace BankAccountManagement.Services
{
    public class Account : IAccount
    {
        //Attributes
        private string accountid;
        private string customerid;
        private List<Transaction> listoftransactions;
        private decimal balance;

        //Properties
        public string AccountId { get => accountid; set => accountid = value; }
        public string CustomerId { get => customerid; set => customerid = value; }
        public decimal Balance { get => balance; set => balance = value; }

        //Methods
        public Account()
        {
            listoftransactions = new List<Transaction>();
            Balance = 0;
            AccountId = string.Empty;
            CustomerId = string.Empty;
        }


        public void Deposit(decimal amount)
        {
            Transaction transaction = new Transaction();
            transaction.Amount = amount;
            transaction.AccountId = this.accountid;
            balance += amount;
            listoftransactions.Add(transaction);            
        }

        public void Withdraw(decimal amount)
        {
            Transaction transaction = new Transaction();
            transaction.Amount = amount;
            transaction.AccountId = accountid;

            if (balance >= amount)
                balance -= amount;

            listoftransactions.Add(transaction);
        }

        public override string ToString()
        {
            string log = string.Empty;
            log += "Transactions for account: " + this.accountid + "\n";
            foreach (var transaction in listoftransactions) {
                log = log + "\n" + transaction.ToString();
            }

            return log;
        }
    }
}

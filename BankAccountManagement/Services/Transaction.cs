using BankAccountLib.Interfaces;
using System;

namespace BankAccountManagement.Services
{
    public class Transaction: ITransaction
    {
        //Attributes
        private decimal amount;
        private string accountid;
        private DateTime isinsertedon;

        //Properties
        public DateTime IsInsertedOn { get => isinsertedon; set => isinsertedon = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public string AccountId { get => accountid; set => accountid = value; }

        //Methods
        public Transaction()
        {
            isinsertedon = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("{0} | {1}", IsInsertedOn, Amount);
        }


    }
}

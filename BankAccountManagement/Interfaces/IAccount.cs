using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountManagement.Services
{
    public interface IAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        string ToString();
    }
}

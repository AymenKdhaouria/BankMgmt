using BankAccountManagement.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountManagement.Interfaces
{
    public interface ICustomer
    {
        void AddAccount(Account acct);
    }
}

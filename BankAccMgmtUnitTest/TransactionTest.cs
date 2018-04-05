using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountManagement.Services;

namespace BankAccMgmtUnitTest
{

    [TestClass]
    public class TransactionTest
    {
        Customer customer = new Customer();
        Account account = new Account();

        public ITransactionService InitializeTests(ref Account account, ref Customer customer)
        {
            customer.CustomerId = "TempCustomerId";
            account.AccountId = "TempAcctNo";
            account.CustomerId = customer.CustomerId;
            customer.AddAccount(account);
            System.Collections.Generic.List<Customer> listofcustomers = new System.Collections.Generic.List<Customer>();
            listofcustomers.Add(customer);
            ITransactionService transactionservice = new TransactionService(listofcustomers);
            return transactionservice;

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WithdrawMoney_Should_ThrowException_When_InsufficientShares() 
        {
            ITransactionService transactionservice = InitializeTests(ref account, ref customer);
            transactionservice.Deposit(account.AccountId, 1000);
            transactionservice.Withdraw(account.AccountId, 1100);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DepositMoney_Should_ThrowException_When_NegativeAmount() 
        {
            ITransactionService transactionservice = InitializeTests(ref account, ref customer);
            transactionservice.Deposit(account.AccountId, -1000);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DepositMoney_Should_ThrowException_When_ZeroAmount()
        {
            ITransactionService transactionservice = InitializeTests(ref account, ref customer);
            transactionservice.Deposit(account.AccountId, 0);
        }

        [TestMethod]
        public void DepositMoney_Should_ThrowException_When_Balance_IsNot_SuccessfullyUpdated()
        {
            ITransactionService transactionservice = InitializeTests(ref account , ref customer);
            transactionservice.Deposit(account.AccountId, 100);
            Assert.AreEqual(account.Balance, Convert.ToDecimal(100));
        }

        [TestMethod]
        public void WithdrawMoney_Should_ThrowException_When_Balance_IsNot_SuccessfullyUpdated()
        {
            ITransactionService transactionservice = InitializeTests(ref account, ref customer);
            transactionservice.Deposit(account.AccountId, 100);
            transactionservice.Withdraw(account.AccountId, 50);
            Assert.AreEqual(account.Balance, Convert.ToDecimal(50));
        }

    }
}

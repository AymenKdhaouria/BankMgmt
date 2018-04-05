namespace BankAccountManagement.Services
{
    public interface ITransactionService
    {
        void Deposit(string accountId, decimal amount);
        void Withdraw(string accountId, decimal amount);
        
    }
}

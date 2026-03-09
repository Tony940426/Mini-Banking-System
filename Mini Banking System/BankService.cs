using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Banking_System
{
    public class BankService
    {
       private List<BankAccount> _bankAccounts;
       private ITransactionLogger _logger;

        public BankService(ITransactionLogger logger)
        {
            _bankAccounts = new List<BankAccount>();
            _logger = logger;
        }

        public void AddBankAccount(BankAccount account)
        {
            _bankAccounts.Add(account);
            _logger.Log($"Bank account added {account.AccountNumber}");
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            if (string.IsNullOrEmpty(accountNumber)) 
            {
                throw new ArgumentException("No account number entered");
            }

            if (amount <= 0 )
            {
                throw new ArgumentException("Deposit must be greated than 0");
            }

            BankAccount userBankAccount = _bankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (userBankAccount == null) 
            {
                throw new ArgumentException("No account found");
            }

            userBankAccount.Deposit(amount);
            _logger.Log($"Deposted {amount:C} into account: {userBankAccount}");

        }
    }
}

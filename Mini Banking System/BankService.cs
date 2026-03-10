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
            if (_bankAccounts.Contains(account)) {
                throw new ArgumentException("Account number already exists");
            }

            if(account == null) {
                throw new ArgumentException("Please enter a account number");
            }


            _bankAccounts.Add(account);
            _logger.Log($"Added Account: {account.AccountNumber}({account.HolderName})");
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            if (string.IsNullOrEmpty(accountNumber)) 
            {
                throw new ArgumentException("No account number entered");
            }

            if (amount <= 0) {             
                throw new ArgumentException("Deposit must be greater than 0");
            }

            BankAccount userBankAccount = _bankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (userBankAccount == null){
                throw new ArgumentException("No account found");
            }

            userBankAccount.Deposit(amount);
            _logger.Log($"Depost {amount:C} into {userBankAccount.AccountNumber}. Balance: {userBankAccount.Balance:C}");

        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            if (string.IsNullOrEmpty(accountNumber)) {
                throw new ArgumentException("No account number entered");
            }

            if (amount <= 0) {
                throw new ArgumentException("Withdraw must be greater than 0");
            }

            BankAccount userBankAccount = _bankAccounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

            if (userBankAccount == null)
               throw new ArgumentException("No account found");

            userBankAccount.Withdraw(amount);
            _logger.Log($"Withdraw {amount:C} from {userBankAccount.AccountNumber}. Balance: {userBankAccount.Balance:C}");
            
        }

        public void PrintAllSummary() {
            Console.WriteLine("");
            Console.WriteLine("---ACCOUNT SUMMARIES---");

            foreach (var account in _bankAccounts) {
                account.DisplayAccountInfo();
            }
        }
    }
}

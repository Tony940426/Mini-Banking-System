using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

        public void TransferBetweenAccount(BankAccount debitaccount, BankAccount creditaccount, decimal amount)
        {
            ValidateTransferInputs(debitaccount, creditaccount, amount);

            debitaccount.Withdraw(amount);
            creditaccount.Deposit(amount);
            _logger.Log($"Transferred {amount:C} from {debitaccount.AccountNumber}. Balance: {debitaccount.Balance:C} to {creditaccount.AccountNumber}. Balance: {creditaccount.Balance:C} ");

        }

        private bool CheckAccountExists(BankAccount account)
        {
            return _bankAccounts.Any(a => a.AccountNumber == account.AccountNumber);
        }

        private bool CheckAccountHasSufficientBalance(BankAccount debitaccount, decimal amount)
        {
            return debitaccount.Balance >= amount;
        }

        private void ValidateTransferInputs(BankAccount debitaccount, BankAccount creditaccount, decimal amount)
        {
            if (string.IsNullOrEmpty(debitaccount.AccountNumber) || string.IsNullOrEmpty(creditaccount.AccountNumber))
            {
                throw new ArgumentException("Account numbers cannot be empty.");
            }

            if (!CheckAccountExists(debitaccount))
            {
                throw new ArgumentException($"Debt account {debitaccount.AccountNumber} does not exist.");
            }

            if (!CheckAccountExists(creditaccount))
            {
                throw new ArgumentException($"Credit account {creditaccount.AccountNumber} does not exist.");
            }

            if (!CheckAccountHasSufficientBalance(debitaccount, amount))
            {
                throw new InvalidOperationException($"Insufficient balance in account {debitaccount.AccountNumber}");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Transfer amount must be greater than zero.");
            }
        }
    }
}

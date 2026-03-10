using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Banking_System
{
    public abstract class BankAccount
    {

        public  string AccountNumber { get; }
        public  string HolderName { get; }
        public decimal Balance { get; protected set; } = 0;
        protected BankAccount(string accountNumber, string holderName)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
        }
        public abstract decimal Withdraw(decimal amount);

        public decimal Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance = amount;
            return Balance;
        }

        public virtual void DisplayAccountInfo()
        {
            Console.Write($"Account Number: {AccountNumber} |");
            Console.Write($" Holder Name: {HolderName} |");
            Console.Write($" Balance: {Balance:C} |");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Banking_System
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; } = 0;
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
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Holder Name: {HolderName}");
            Console.WriteLine($"Balance: {Balance:C}");
        }
    }

}

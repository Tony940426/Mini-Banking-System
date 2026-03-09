using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Banking_System
{
    internal class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount() : base()
        {
            
        }

        public override decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
            return Balance;
        }

        public decimal ApplyMonthlyInterest()
        {
            Balance = Balance * (1 + (InterestRate/100));
            return Balance;
        }

        public override void DisplayAccountInfo()
        {
            base.DisplayAccountInfo();
            Console.WriteLine($"Balance with interest applied of {InterestRate}%");
        }
    }
}

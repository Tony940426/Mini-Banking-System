using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Banking_System
{
    public class CheckingAccount : BankAccount
    {
        public decimal OverdraftLimit { get; set; }
        public override decimal Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            if (Balance + OverdraftLimit < amount)
            {
                throw new ArgumentException("Withdrawal exceeds bank balance and overdraft limit");
            }
            else
            {
                return Balance - amount;
            }
        }

        public override void DisplayAccountInfo()
        {
            base.DisplayAccountInfo();
            Console.WriteLine($"Overdraft limit of ${OverdraftLimit:C}\n");
        }
    }
}
